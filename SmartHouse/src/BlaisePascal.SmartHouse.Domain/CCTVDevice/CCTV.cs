using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class CCTV: AbstractDevice
    {
        //Const
        public const int minimumTiltDegrees = -90;
        public const int maximumTiltDegrees = 90;
        public const double maximumZoom = 5.0;

        //Properties
        public int CurrentTilt { get; private set; }
        public double CurrentZoom { get; private set; }
        public CCTVStatus CCTVStatus { get; private set; }
        public List<Recording> RecordingsSaved { get; private set; }
        public List<Photo>PhotosSaved { get; private set; }

        //Constructor
        public CCTV(string name): base(name) 
        {
            CurrentTilt = 0;
            CurrentZoom = 1.0;
            CCTVStatus = CCTVStatus.NotRecording;
            RecordingsSaved = new List<Recording>();
            PhotosSaved = new List<Photo>();
        }
        public CCTV(Guid guid, string name):base(guid, name) 
        {
            CurrentTilt = 0;
            CurrentZoom = 1.0;
            CCTVStatus = CCTVStatus.NotRecording;
            RecordingsSaved = new List<Recording>();
            PhotosSaved = new List<Photo>();
        }


        //Methods
        public void Move(int degrees)
        {
            OnValidator();
            CurrentTilt = Math.Clamp(CurrentTilt + degrees, minimumTiltDegrees, maximumTiltDegrees);
        }
        
        public void Zoom(double newZoom)
        {
            OnValidator();
            if (newZoom > maximumZoom || newZoom < 1)
                throw new InvalidOperationException("the input zoom amount is not possible on this device");
                
            CurrentZoom = newZoom;

        }

        public void StartRecording()
        {
            OnValidator();
            if (CCTVStatus == CCTVStatus.Recording)
            {
                throw new InvalidOperationException("You are already recording");
            }
            CCTVStatus = CCTVStatus.Recording;
            LastStatusChangeTime = DateTime.UtcNow;
            

        }
        public void StopRecording()
        {
            OnValidator();
            if (CCTVStatus == CCTVStatus.NotRecording)
            {
                throw new InvalidOperationException("You are not recording");
            }

            CCTVStatus = CCTVStatus.NotRecording;
            RecordingsSaved.Add(new Recording(LastStatusChangeTime.ToString(), LastStatusChangeTime, DateTime.UtcNow - LastStatusChangeTime));
            LastStatusChangeTime = DateTime.UtcNow;


        }

        public void ClearMemory()
        {
            OnValidator();
            RecordingsSaved.Clear();
            PhotosSaved.Clear();
        }

        public void SavePhoto(string name)
        {
            OnValidator();
            PhotosSaved.Add(new Photo(name + ".png", CurrentZoom, CurrentTilt, DateTime.UtcNow));
        }
        public void DeleteFile(Filetype file, int position)
        {
            OnValidator();
            if (file == Filetype.Photo)
            {
                PhotosSaved.RemoveAt(position);
            }
            else if (file == Filetype.Video)
            {
                RecordingsSaved.RemoveAt(position);
            }
        }
    }
}
