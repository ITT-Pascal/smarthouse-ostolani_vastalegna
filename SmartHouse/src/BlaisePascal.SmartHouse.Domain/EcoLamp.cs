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
        
        public EcoLamp()
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;

        }

        public override void TurnOff()
        {
            if (IsOn) 
                IsOn = false;
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

        public void EcoModeBrightness()
        {
            int EcoModeBrightnessValue = 40;
            if (IsOn && BrightnessLevel>EcoModeBrightnessValue) {
                BrightnessLevel = EcoModeBrightnessValue;
            }
        }
        
        public void TurnOffAfterTime()
        {
            DateTime InitialTime = DateTime.UtcNow;

            if (IsOn)
            {
                if (!(OnTime == DateTime.MinValue) && DateTime.Now - OnTime > TimeSpan.FromMinutes(50))
                {
                    TurnOff();
                }
            }
                
        }
    }
}
