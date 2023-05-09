using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class SpellManager : GameBehaviour<SpellManager>
{

    public class Spells : MonoBehaviour
    {
        public int dmg;
        public int speed;
        public int cost;
    }

    public Spells fireball;

    public GameObject fireballPrefab;
    public GameObject spawnPoint;

    public enum SpellType { None, Fireball}
    public SpellType spellType;

    public GameObject spellAim;
    // Start is called before the first frame update
    void Start()
    {


        #region spellStats

        fireball = new Spells();
        fireball.dmg = 20;
        fireball.cost = 4;
        fireball.speed = 3;
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        Vector3 crosshairPos = new Vector3(newMousePos.x, 1, newMousePos.z);
        spellAim.transform.position = crosshairPos;

        switch(spellType)
        {
            case SpellType.None:
                Cursor.visible = true;
                spellAim.SetActive(false);
                break;
            case SpellType.Fireball:
                Cursor.visible = false;

                spellAim.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.None;
                if (Input.GetMouseButtonDown(0))
                {
                    SpawnFireball();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    spellType = SpellType.None;
                }
                break;
        }
    }


    public void SpawnFireball()
    {

        //remove money
        _CM.manaCount -= fireball.cost;
        _UI.UpdateManaMoney();



        Vector3 mousePos = Input.mousePosition;
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        GameObject fireballGO = Instantiate(fireballPrefab, spawnPoint.transform.position, Quaternion.identity);
        fireballGO.GetComponent<Fireball>().target = newMousePos;
        spellType = SpellType.None;



    }
}
