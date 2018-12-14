using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop5
{
    public interface Inventary
    {
        void Take_Invent();
        void Back_Invent();
    }

    public interface IBall : Inventary
    {
        void Throw();
        void Play();
    }

    public interface ITennisBall : IBall
    {
        new void Play();
        void DoExercise();
    }

    public interface IBacketBall : IBall
    {
        new void Play();
    }

    public interface IExersise
    {
        int GetExp();
        void DoExercise(int hour);
    }

    public interface ISportGame
    {
        void Play(int hour);
    }
}