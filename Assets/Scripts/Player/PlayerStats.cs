using System;
public class PlayerStats 
{
    public event Action OnNoHpLeft;

    public int HPCount { get; private set;}
    public int ScoreCount { get; private set; }

    public PlayerStats(int startLifeCount)
    {
        HPCount = startLifeCount;
        ScoreCount = 0;
    }
    public void SetHP(int count)
    {
        if (count < 0) return;

        HPCount = count;
    }
    public void SetScore(int count)
    {
        if (count < 0) return;

        ScoreCount = count;
    }
    public void IncreaseScore(int count)
    {
        ScoreCount += count;
    }
    public void DecreaseHP(int amount)
    {
        HPCount -= amount;

        if (HPCount == 0)
        {
            OnNoHpLeft?.Invoke();
        }
    }
}
