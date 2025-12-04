using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class CCTV:AbstractDevice
    {

        public const int minimumTiltDegrees = -90;
        public const int maximumTiltDegrees = 90;
        public const double maximumZoom = 5.0;
        public int CurrentTilt { get; private set; }
        public double CurrentZoom { get; private set; }
        public CCTVStatus CCTVStatus { get; private set; }
        public List<Recording> RecordingsSaved { get; private set; }
        public DateTime RecordStart;
        public TimeSpan RecordLength;

        public CCTV(string name): base(name) 
        {
            CurrentTilt = 0;
            CurrentZoom = 1.0;
            CCTVStatus = CCTVStatus.NotRecording;
            RecordingsSaved = new List<Recording>();
        }
        public CCTV(Guid guid, string name):base(guid, name) 
        {
            CurrentTilt = 0;
            CurrentZoom = 1.0;
            CCTVStatus = CCTVStatus.NotRecording;
            RecordingsSaved = new List<Recording>();
        }


        
        

        public void move(int degrees) => CurrentTilt = Math.Clamp(minimumTiltDegrees, maximumTiltDegrees, CurrentTilt + degrees);
        

        public void zoom(double newZoom)
        {
            OnValidator();
            if (newZoom > maximumZoom || newZoom < 1)
                throw new Exception("the input zoom amount is not possible on this device");
                
            CurrentZoom = newZoom;
            
        }
        public void startRecording()
        {
            OnValidator();
            if (CCTVStatus == CCTVStatus.Recording)
            {
                throw new Exception("You are already recording");
            }
            CCTVStatus = CCTVStatus.Recording;
            LastStatusChangeTime = DateTime.UtcNow;
            RecordStart = DateTime.UtcNow;

        }
        public void stopRecording(string name)
        {
            OnValidator();
            if (CCTVStatus == CCTVStatus.NotRecording) 
            {
                throw new Exception("You are not recording");
            }
            string FileName = name + ".mp4";
            CCTVStatus = CCTVStatus.NotRecording;
            LastStatusChangeTime = DateTime.UtcNow;
            RecordLength = LastStatusChangeTime - RecordStart;
            RecordingsSaved.Add(new Recording(FileName, CurrentZoom, CurrentTilt, RecordLength));
        }
        public void clearMemory() => RecordingsSaved.Clear();


    }
}
