using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DetachChildren detachChildren;
    [Header("boss objects")]
    public GameObject _bossSoldierObj, _bossRamboObj, _bossKratosObj, _evilbossSoldierObj, _evilbossRamboObj, _evilbossKratosObj;
    [Header("buttons")]
    public Button _bossSoldierButton, _bossRamboButton, _bossKratosButton;
    [Header("canvas")]
    public Canvas bossPickCanvas, _HUD, _pausee;
    [Header("images")]
    public Image _soldierAvatar, _ramboAvatar, _kratosAvatar, _healthBar, _heart1, _heart2, _heart3;
    public int seconds = 0, minutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        _pausee.gameObject.SetActive(false);
        BossPickCanvasA();
        detachChildren = GameObject.FindFirstObjectByType<DetachChildren>();

        StartCoroutine(Timer());
    }
    private void Update()
    {
        if(minutes >= 5)
        {
            Debug.Log("Win");
        }
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
                _evilbossRamboObj.GetComponent<Unit>().enabled = true;
                _evilbossRamboObj.GetComponent<CapsuleCollider>().enabled = true;
                _evilbossKratosObj.GetComponent<Unit>().enabled = false;
                _evilbossKratosObj.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (gameObject == _bossRamboObj)
            {
                _evilbossSoldierObj.GetComponent<Unit>().enabled = true;
                _evilbossSoldierObj.GetComponent<CapsuleCollider>().enabled = true;
                _evilbossKratosObj.GetComponent<Unit>().enabled = false;
                _evilbossKratosObj.GetComponent<CapsuleCollider>().enabled = false;
            }
            else if (gameObject == _bossKratosObj)
            {
                _evilbossSoldierObj.GetComponent<Unit>().enabled = true;
                _evilbossSoldierObj.GetComponent<CapsuleCollider>().enabled = true;
                _evilbossRamboObj.GetComponent<Unit>().enabled = false;
                _evilbossRamboObj.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        else
        {
            if (gameObject == _bossSoldierObj)
            {
                _evilbossRamboObj.GetComponent<Unit>().enabled = false;
                _evilbossRamboObj.GetComponent<CapsuleCollider>().enabled = false;
                _evilbossKratosObj.GetComponent<Unit>().enabled = true;
                _evilbossKratosObj.GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (gameObject == _bossRamboObj)
            {
                _evilbossSoldierObj.GetComponent<Unit>().enabled = false;
                _evilbossSoldierObj.GetComponent<CapsuleCollider>().enabled = false;
                _evilbossKratosObj.GetComponent<Unit>().enabled = true;
                _evilbossKratosObj.GetComponent<SphereCollider>().enabled = true;
            }
            else if (gameObject == _bossKratosObj)
            {
                _evilbossSoldierObj.GetComponent<Unit>().enabled = false;
                _evilbossSoldierObj.GetComponent<SphereCollider>().enabled = false;
                _evilbossRamboObj.GetComponent<Unit>().enabled = true;
                _evilbossRamboObj.GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    public void BossSoldierButton()
    {
        detachChildren.StealTheChild(_bossSoldierObj);

        _soldierAvatar.enabled = true;
        _kratosAvatar.enabled = false;
        _ramboAvatar.enabled = false;

        BossPickCanvasD();
    }
    public void BossRamboButton()
    {
        detachChildren.StealTheChild(_bossRamboObj);

        _soldierAvatar.enabled = false;
        _kratosAvatar.enabled = false;
        _ramboAvatar.enabled = true;

        BossPickCanvasD();
    }
    public void BossKratosButton()
    {
        detachChildren.StealTheChild(_bossKratosObj);

        _soldierAvatar.enabled = false;
        _kratosAvatar.enabled = true;
        _ramboAvatar.enabled = false;

        BossPickCanvasD();
    }

    public void BossPickCanvasA()
    {
        _bossSoldierButton.gameObject.SetActive(true);
        _bossRamboButton.gameObject.SetActive(true);
        _bossKratosButton.gameObject.SetActive(true);

        bossPickCanvas.gameObject.SetActive(true);
        _HUD.gameObject.SetActive(false);
        _pausee.gameObject.SetActive(false);
        Time.timeScale = 0.00000000000000000001f;
    }
    public void BossPickCanvasD()
    {
        _bossSoldierButton.gameObject.SetActive(false);
        _bossRamboButton.gameObject.SetActive(false);
        _bossKratosButton.gameObject.SetActive(false);

        bossPickCanvas.gameObject.SetActive(false);
        _HUD.gameObject.SetActive(true);
        _pausee.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.timeScale > 0f)
            {
                _pausee.gameObject.SetActive(true);
                _HUD.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                _pausee.gameObject.SetActive(false);
                _HUD.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }

    public void Quit()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        Debug.Log("deleting system32");
    }
}
