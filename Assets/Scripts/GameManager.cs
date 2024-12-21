using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DetachChildren detachChildren;
    public GameObject _bossSoldierObj, _bossRamboObj, _bossKratosObj;
    public Button _bossSoldierButton, _bossRamboButton, _bossKratosButton;
    public Canvas bossPickCanvas;
    int seconds = 0, minutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        BossPickCanvasA();
        detachChildren = GameObject.FindFirstObjectByType<DetachChildren>();

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (!detachChildren.isDead)
        {
            yield return new WaitForSeconds(1);
            if (seconds == 59)
            {
                seconds = 0;
                minutes++;
                SendRandomBoss();
            }
            else
            {
                seconds++;
            }
        }
    }

    void SendRandomBoss()
    {
        int randomint = Random.Range(0, 9);
        GameObject gameObject = detachChildren.childObject;
        if (randomint <= 4)
        {
            if (gameObject == _bossSoldierObj)
            {
                _bossRamboObj.GetComponent<Unit>().enabled = true;
                _bossRamboObj.GetComponent<CapsuleCollider>().enabled = true;
                _bossKratosObj.GetComponent<Unit>().enabled = false;
                _bossKratosObj.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (gameObject == _bossRamboObj)
            {
                _bossSoldierObj.GetComponent<Unit>().enabled = true;
                _bossSoldierObj.GetComponent<CapsuleCollider>().enabled = true;
                _bossKratosObj.GetComponent<Unit>().enabled = false;
                _bossKratosObj.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (gameObject == _bossKratosObj)
            {
                _bossSoldierObj.GetComponent<Unit>().enabled = true;
                _bossSoldierObj.GetComponent<CapsuleCollider>().enabled = true;
                _bossRamboObj.GetComponent<Unit>().enabled = false;
                _bossRamboObj.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        else
        {
            if (gameObject == _bossSoldierObj)
            {
                _bossRamboObj.GetComponent<Unit>().enabled = false;
                _bossRamboObj.GetComponent<CapsuleCollider>().enabled = false;
                _bossKratosObj.GetComponent<Unit>().enabled = true;
                _bossKratosObj.GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (gameObject == _bossRamboObj)
            {
                _bossSoldierObj.GetComponent<Unit>().enabled = false;
                _bossSoldierObj.GetComponent<CapsuleCollider>().enabled = false;
                _bossKratosObj.GetComponent<Unit>().enabled = true;
                _bossKratosObj.GetComponent<SphereCollider>().enabled = true;
            }
            else if (gameObject == _bossKratosObj)
            {
                _bossSoldierObj.GetComponent<Unit>().enabled = false;
                _bossSoldierObj.GetComponent<SphereCollider>().enabled = false;
                _bossRamboObj.GetComponent<Unit>().enabled = true;
                _bossRamboObj.GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    public void BossSoldierButton()
    {
        detachChildren.StealTheChild(_bossSoldierObj);

        _bossSoldierButton.gameObject.SetActive(false);
        _bossRamboButton.gameObject.SetActive(true);
        _bossKratosButton.gameObject.SetActive(true);

        BossPickCanvasD();
    }
    public void BossRamboButton()
    {
        detachChildren.StealTheChild(_bossRamboObj);

        _bossSoldierButton.gameObject.SetActive(true);
        _bossRamboButton.gameObject.SetActive(false);
        _bossKratosButton.gameObject.SetActive(true);

        BossPickCanvasD();
    }
    public void BossKratosButton()
    {
        detachChildren.StealTheChild(_bossKratosObj);

        _bossSoldierButton.gameObject.SetActive(true);
        _bossRamboButton.gameObject.SetActive(true);
        _bossKratosButton.gameObject.SetActive(false);

        BossPickCanvasD();
    }

    public void BossPickCanvasA()
    {
        bossPickCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BossPickCanvasD()
    {
        bossPickCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Debug.Log("deleting system32");
    }
}
