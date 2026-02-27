using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class LedMatrix: AbstractDevice
    {
        public AbstractLamp [,] Matrix { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LedMatrix(string name, int height, int width) : base(name)
        {
            Width = width;
            Height = height;
            Matrix = new AbstractLamp[height, width];
        }

        public LedMatrix(string name, AbstractLamp[,] matrix) : base(name)
        {
            Matrix = matrix;
            Width = Matrix.GetLength(1);
            Height = Matrix.GetLength(0);
        }



        //Methods
        public void AddLampInPosition(AbstractLamp lamp, int row, int column)
        {
            if (Matrix[row, column] != null)
                throw new ArgumentException("Not avaiable place");

            Matrix[row, column] = lamp;
        }

        public void RemoveLamp(string name)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Name == name)
                    {
                        Matrix[r, c] = null;
                        return;
                    }
                }
            }

            throw new ArgumentException("No lamps with this name");
        }

        public void RemoveLamp(Guid id)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Id == id)
                    {
                        Matrix[r, c] = null;
                        return;
                    }
                }
            }

            throw new ArgumentException("No lamps with this guid");
        }

        public void RemoveLampInPosition(int row, int column)
        {
            Matrix[row, column] = null;
        }

        public override void SwitchOn()
        {
            foreach (AbstractLamp i in Matrix)
            {
                if (i != null)
                {
                        i.SwitchOn();
                }
            }

        }

        public override void SwitchOff()
        {
            foreach (AbstractLamp i in Matrix)
            {
                if (i != null)
                {
                    i.SwitchOff();
                }
            }

        }

        public void SwitchOneOneLamp(Guid id) { GetLamp(id).SwitchOn(); }
        public void SwitchOneOneLamp(string name) { GetLamp(name).SwitchOn(); }
        public void SwitchOffOneLamp(Guid id) { GetLamp(id).SwitchOff(); }
        public void SwitchOffOneLamp(string name) { GetLamp(name).SwitchOff(); }

        public void SetBrightness(Brightness newbrightness)
        {
            foreach (AbstractLamp lamp in Matrix)
            {
                if (lamp != null)
                    lamp.SetBrightness(newbrightness);
            }
        }
        public void SetBrightnessOneLamp(Brightness newbrightness, Guid id) { GetLamp(id).SetBrightness(newbrightness); }
        public void SetBrightnessOneLamp(Brightness newbrightness, string name) { GetLamp(name).SetBrightness(newbrightness); }

        public AbstractLamp FindLampWithMaxBrightness()
        {
            NotNullValidator();

            AbstractLamp maxLamp = null;

            foreach (AbstractLamp l in Matrix)
            {
                if (l == null)
                    continue;

                if (maxLamp == null || l.Brightness > maxLamp.Brightness)
                    maxLamp = l;
            }

            return maxLamp;
        }

        public AbstractLamp FindLampWithMinBrightness()
        {
            NotNullValidator();

            AbstractLamp minLamp = null;

            foreach (AbstractLamp l in Matrix)
            {
                if (l == null)
                    continue;

                if (minLamp == null || l.Brightness < minLamp.Brightness)
                    minLamp = l;
            }

            return minLamp;
        }

        public void SetChessboardPattern()
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] == null) continue;

                    if ((r+c) %2 == 0) Matrix[r, c].SwitchOn();
                    else Matrix[r, c].SwitchOff();
                }
            }
        }


        //Metodi get privati


        public AbstractLamp GetLamp(Guid id)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Id == id)
                    {
                        return Matrix[r, c];
                    }
                }
            }
            throw new ArgumentException("No lamps with this guid");
        }

        public AbstractLamp GetLamp(string name)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Name == name)
                    {
                        return Matrix[r, c];
                    }
                }
            }
            throw new ArgumentException("No lamps with this name");
        }

        public void NotNullValidator()
        {
            foreach (var lamp in Matrix)
            {
                if (lamp != null)
                    return;
            }
            throw new Exception("All the matrix position are null");
        }

    }
}
