using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillGridManager : MonoBehaviour
{
    public GridLayoutGroup headGrid;
    public GridLayoutGroup bodyGrid;
    public GridLayoutGroup legsGrid;
    public GridLayoutGroup feetGrid;

    private Sprite[] headSprites;
    private Sprite[] bodySprites;
    private Sprite[] legSprites;
    private Sprite[] feetSprites;

    public GameObject spritePrefab;

    private void Start()
    {
        FillSprites();
    }
    public void FillOnClick()
    {
        FillGrid(headGrid, headSprites);
        FillGrid(bodyGrid, bodySprites);
        FillGrid(legsGrid, legSprites);
        FillGrid(feetGrid, feetSprites);
    }

    private void FillSprites()
    {
        headSprites = Resources.LoadAll<Sprite>("head_outfits");
        bodySprites = Resources.LoadAll<Sprite>("body_outfits");
        legSprites = Resources.LoadAll<Sprite>("legs_outfits");
        feetSprites = Resources.LoadAll<Sprite>("feet_outfits");
    }

    private void FillGrid(GridLayoutGroup grid, Sprite[] sprites)
    {
        foreach (Transform child in grid.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (Sprite sprite in sprites)
        {
            GameObject newSprite = Instantiate(spritePrefab, grid.transform);
            newSprite.GetComponent<Image>().sprite = sprite;
        }
    }
}
