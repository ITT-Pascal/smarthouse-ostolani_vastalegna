using BlaisePascal.SmartHouse.Domain.CCTVDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CCTVTest
    {

        //Move / Tilt


        [Fact]
        public void When_CCTVIsOffAndTryToMove_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            

            Assert.Throws<InvalidOperationException>(() => cam.Move(10));
        }

        [Fact]
        public void When_MovingBeyondMaximumTilt_ShouldClampToMax()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.Move(200);

            Assert.Equal(CCTV.maximumTiltDegrees, cam.CurrentTilt);
        }

        [Fact]
        public void When_MovingBeyondMinimumTilt_ShouldClampToMin()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.Move(-200);

            Assert.Equal(CCTV.minimumTiltDegrees, cam.CurrentTilt);
        }

        [Fact]
        public void When_MovingWithinRange_ShouldUpdateTilt()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.Move(20);

            Assert.Equal(20, cam.CurrentTilt);
        }


        //Zoom


        [Fact]
        public void When_CCTVIsOffAndTryToZoom_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            

            Assert.Throws<InvalidOperationException>(() => cam.Zoom(2.0));
        }

        [Fact]
        public void When_ZoomIsBelow1_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            Assert.Throws<InvalidOperationException>(() => cam.Zoom(0.5));
        }

        [Fact]
        public void When_ZoomIsAboveMaximum_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            Assert.Throws<InvalidOperationException>(() => cam.Zoom(CCTV.maximumZoom + 1));
        }

        [Fact]
        public void When_ZoomIsValid_ShouldApplyZoom()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.Zoom(3.0);

            Assert.Equal(3.0, cam.CurrentZoom);
        }


        //Start Recording

        [Fact]
        public void When_CCTVIsOffAndTryToStartRecording_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");

            

            Assert.Throws<InvalidOperationException>(() => cam.StartRecording());
        }

        [Fact]
        public void When_AlreadyRecording_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();

            Assert.Throws<InvalidOperationException>(() => cam.StartRecording());
        }

        [Fact]
        public void When_NotRecording_ShouldStartRecording()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();

            Assert.Equal(CCTVStatus.Recording, cam.CCTVStatus);
        }


        //Stop Recording

        [Fact]
        public void When_NotRecordingAndTryToStop_ShouldThrow()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();

            Assert.Throws<InvalidOperationException>(() => cam.StopRecording());
        }

        [Fact]
        public void When_Recording_ShouldStopAndSaveRecording()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();

            cam.StopRecording();

            Assert.Equal(CCTVStatus.NotRecording, cam.CCTVStatus);
            Assert.Single(cam.RecordingsSaved);
        }

        [Fact]
        public void When_StoppingRecording_ShouldSaveCorrectStartTime()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();

            DateTime start = cam.LastStatusChangeTime;
            cam.StopRecording();

            Assert.Equal(start, cam.RecordingsSaved[0].RecordStart);
        }

        [Fact]
        public void When_StoppingRecording_ShouldSaveNonZeroDuration()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();

            Thread.Sleep(50);
            cam.StopRecording();

            Assert.True(cam.RecordingsSaved[0].RecordLength.TotalMilliseconds > 0);
        }


        //Clear Memory

        [Fact]
        public void When_ClearMemory_ShouldRemoveAllRecordings()
        {
            CCTV cam = new CCTV("Cam");
            cam.SwitchOn();
            cam.StartRecording();
            cam.StopRecording();

            cam.ClearMemory();

            Assert.Empty(cam.RecordingsSaved);
        }

    }
}
