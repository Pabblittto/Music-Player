using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    interface IPlayerAdapter
    {
        /// <summary>
        /// return amount of seconds 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        TimeSpan Load(string filePath);
        void Play();
        void Pause();
        void Stop();

        /// <summary>
        /// Volume is a number between 0 and 1.0
        /// </summary>
        /// <param name=""></param>
        void SetVolume(float volume);

        void SetCertainSecond(int Seconds);
        



    }
}
