using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {

        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;
        public const int PowerSaveMaxMinutesOn = 50;
        public const int EcoModeBrightnessValue = 40;

        
        //TODO: Resolve the OnTime test issue
        //ONLY FOR TESTING PURPOSES
        public void SetOnTime(DateTime time)
        {
            LastModifiedTime = time;
        }

        public EcoLamp(Guid guid, string name)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = guid;
            Name = name;
        }

        public EcoLamp(string name)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = Guid.NewGuid();
            Name = name;
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                LastModifiedTime = DateTime.UtcNow;
            }
        }
        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                LastModifiedTime = DateTime.UtcNow;
            }
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
            if (IsOn && BrightnessLevel>EcoModeBrightnessValue) {
                BrightnessLevel = EcoModeBrightnessValue;
            }
        }

        public void TurnOffAfterTime()
        {
            if (IsOn)
            {
                if (DateTime.Now - LastModifiedTime > TimeSpan.FromMinutes(PowerSaveMaxMinutesOn))
                {
                    TurnOff();
                }
            }
                
        }
    }
}
