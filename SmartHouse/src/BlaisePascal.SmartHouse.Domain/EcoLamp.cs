using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: LampModel
    {

        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;

        
        public DateTime CreationTime { get; private set; }
        public DateTime OnTime {  get; private set; }

        //TODO: Resolve the OnTime test issue

        //ONLY FOR TESTING PURPOSES
        public void SetOnTime(DateTime time)
        {
            OnTime = time;
        }

        public EcoLamp(Guid guid)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = guid;
        }

        public EcoLamp()
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = new Guid();
        }

        public override void TurnOff()
        {
            if (IsOn) 
                IsOn = false;
                OnTime = DateTime.MinValue;
        }
        public override void TurnOn()
        {
            if(!IsOn)
                IsOn = true;
                OnTime = DateTime.UtcNow;
        }

        public override void SetBrightness(int levelOfBrightness)
        {
            if (levelOfBrightness < MinBrightnessLevel || levelOfBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            }
            BrightnessLevel = levelOfBrightness;
        }

        public void SetEcoModeBrightness()
        {
            int EcoModeBrightnessValue = 40;
            if (IsOn && BrightnessLevel>EcoModeBrightnessValue) {
                BrightnessLevel = EcoModeBrightnessValue;
            }
        }

        public void TurnOffAfterTime()
        {
            int PowerSaveMaxMinutesOn = 50;
            if (IsOn)
            {
                if (!(OnTime == DateTime.MinValue) && DateTime.Now - OnTime > TimeSpan.FromMinutes(PowerSaveMaxMinutesOn))
                {
                    TurnOff();
                }
            }
                
        }
    }
}
