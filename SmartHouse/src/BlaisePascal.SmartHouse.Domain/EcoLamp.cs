using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp
    {

        public const int MaxBrightnessLevel = 100;
        

        public bool IsOn { get; private set; }
        public int BrightnessLevel { get; private set; }
        public DateTime CurrentTime => DateTime.UtcNow;
        

        public EcoLamp()
        {
            IsOn = false;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
        public void TurnOn()
        {
            IsOn = true;
        }

        public void SetBrightness(int levelOfBrightness)
        {
            if (levelOfBrightness < 0 || levelOfBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException("Brightness level must be between 0 and MaxBrightnessLevel.");
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
                if (CurrentTime - InitialTime > TimeSpan.FromMinutes(50))
                {
                    TurnOff();
                }
            }
                
        }
    }
}
