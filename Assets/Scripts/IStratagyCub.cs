
using System;

interface IStratagyCub
{
    float GetHeight();
    float GetHeight(float otherHeiht);
}


class StandartStratagyCub : IStratagyCub
{
    private float MaxHeight { get; set; }

   public StandartStratagyCub ()
    {

    }

    public float GetHeight()
    { 

    }

    public float GetHeight(float otherHeiht)
    {
        if (otherHeiht == 0)
            return GetHeight();
        else

        {
            return 0;
        }
    }
}


