#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace CarEventsWithLambdas
{
    public class Car
    {
        #region Basic Car state data / constructors
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public int slowSpeed { get; set; }
        public string PetName { get; set; }

        // Is the car alive or dead?
        private bool carIsDead;

        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp, int slowSpeed)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
            this.slowSpeed = slowSpeed;
        }
        #endregion

        // This delegate works in conjunction with the
        // Car's events.
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        // This car can send these events.
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        public event CarEngineHandler SlowedDown;

        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                if (Exploded != null)
                    OnExplodedMessage(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;

                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed
                  && AboutToBlow != null)
                {
                    OnAboutToBlow(this, new CarEventArgs("Careful buddy!  Gonna blow!"));
                }

                if (CurrentSpeed <= slowSpeed)
                    OnSlowedDown(this, new CarEventArgs("Speed is slow"));

                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        protected virtual void OnExplodedMessage(object sender, CarEventArgs cme)
        {
            if (this.Exploded != null)
            {
                this.Exploded(sender, cme);
            }
        }

        protected virtual void OnAboutToBlow(object sender, CarEventArgs cme)
        {
            if (this.AboutToBlow != null)
            {
                this.AboutToBlow(sender, cme);
            }
        }

        protected virtual void OnSlowedDown(object sender, CarEventArgs cme)
        {
            if (this.SlowedDown != null)
            {
                this.Exploded(sender, cme);
            }
        }
    }
}
