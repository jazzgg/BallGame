using UnityEngine.UI;

public class PlayerUI 
{
    private Text _scoreCount;
    private Text _lifeCount;

    public PlayerUI(Text scoreCountText, Text lifeCountText)
    {
        _scoreCount = scoreCountText;
        _lifeCount = lifeCountText;
    }
    public void Disable()
    {
        _lifeCount.gameObject.SetActive(false);
        _scoreCount.gameObject.SetActive(false);
    }
    public void Enable()
    {
        _lifeCount.gameObject.SetActive(true);
        _scoreCount.gameObject.SetActive(true);
    }
    public void SetScore(int newScoreCount)
    {
        _scoreCount.text = newScoreCount.ToString();
    }
    public void SetHP(int newLifeCount)
    {
        _lifeCount.text = newLifeCount.ToString();
    }
}
