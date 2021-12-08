using UnityEngine;

public class LosePanel
{
    private GameObject _losePanelGameojbect;

    public LosePanel(GameObject losePanelGameobject)
    {
        _losePanelGameojbect = losePanelGameobject;
    }
    public void Enable()
    {
        _losePanelGameojbect.SetActive(true);
    }
    public void Disable()
    {
        _losePanelGameojbect.SetActive(false);
    }
}
