using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject reticle;
    public GameObject bulletPrefab;
    public Text lifeText;
    public Text text;
    int maxAmmo = 10;
    int ammo;
    float distance = 2f;
    float speed = 30f;
    float reloadTime = 1.6f;
    bool reloading;
    bool mouseOutside;
    public Color currentColor;
    int life = 3;

    string bulName;

    bool triggerDown = false;

    void Start()
    {
        gameOverText.SetActive(false);
        ammo = maxAmmo;
        mouseOutside = false;
        reloading = false;
        UpdateAmmo(0);
        bulName = "red";
        currentColor = Color.red;
        lifeText.text = "Life: " + life;
    }

    void UpdateAmmo(int dAmmo)
    {
        ammo += dAmmo;
        text.text = "Ammo: " + ammo.ToString();
    }

    void MoveReticle()
    {
        reticle.transform.position = Input.mousePosition;
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = distance;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = (pos - transform.position).normalized * speed;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject bullet = Instantiate(bulletPrefab, pos, rotation) as GameObject;

        bullet.name = bulName;
        bullet.GetComponentInChildren<Renderer>().material.color = currentColor;
        bullet.GetComponent<Rigidbody>().velocity = direction;
        Destroy(bullet, 3f);
        UpdateAmmo(-1);
    }

    string ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("B"))
        {
            bulName = "red";
            currentColor = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("X"))
        {
            bulName = "blue";
            currentColor = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("A"))
        {
            bulName = "green";
            currentColor = Color.green;
        }
        return bulName;
    }

    void Reload()
    {
        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine()
    {
        text.text = "Reloading...";
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        UpdateAmmo(maxAmmo - ammo);
    }

    bool MouseOutsideScreen()
    {
        return (Input.mousePosition.x < 0f ||
            Input.mousePosition.x > Screen.width ||
            Input.mousePosition.y < 0f ||
            Input.mousePosition.y > Screen.height);
    }

    void CheckMouseOutside()
    {
        if ((Input.mousePosition.x < 0f ||
            Input.mousePosition.x > Screen.width ||
            Input.mousePosition.y < 0f ||
            Input.mousePosition.y > Screen.height) && !mouseOutside)
        {
            mouseOutside = true;
            MouseOutside(true);
        }

        else if (!(Input.mousePosition.x < 0f ||
            Input.mousePosition.x > Screen.width ||
            Input.mousePosition.y < 0f ||
            Input.mousePosition.y > Screen.height) && mouseOutside)
        {
            mouseOutside = false;
            MouseOutside(false);
        }
    }

    void MouseOutside(bool outside)
    {
        if (outside && !reloading)
        {
            Reload();
        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            ChangeColor();
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetAxis("LeftTrigger") > 0) && ammo > 0 && !reloading && !triggerDown)
        {
            triggerDown = true;
            Shoot();
        }
        if(Input.GetAxis("LeftTrigger") <= 0)
        {
            triggerDown = false;
        }
        CheckMouseOutside();
        MoveReticle();
    }

    private void OnTriggerEnter(Collider other)
    {
        life -= 1;
        lifeText.text = "Life: " + life;
        if(life <= 0)
        {
            this.gameObject.SetActive(false);
            gameOverText.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
    public void Hit(Collider col)
    {
        OnTriggerEnter(col);
    }
}