using UnityEngine;
using TMPro;
using UnityEngine.UI;

// handles the between-level upgrade shop
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI creditsText;

    [Header("Upgrade Buttons")]
    public Button damageButton;
    public Button speedButton;
    public Button armorButton;

    [Header("Cost Settings")]
    public int damageCost = 50;
    public int speedCost = 50;
    public int armorCost = 75;

    [Header("Audio")]
    public AudioClip purchaseClip;
    public AudioClip cantAffordClip;
    private AudioSource audioSource;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateCreditsText();
    }

    // called by LevelManager when the level complete panel opens
    public void ShowUpgrades()
    {
        UpdateCreditsText();
    }

    public void UpdateCreditsText()
    {
        if (creditsText != null)
            creditsText.text = "Shell Credits: " + GameManager.Instance.shellCredits + " SC";
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    void GreyOutButton(Button button)
    {
        button.interactable = false;
        ColorBlock cb = button.colors;
        cb.disabledColor = new Color(0.5f, 0.5f, 0.5f, 1f);
        button.colors = cb;
    }

    public void ResetUpgradeButtons()
    {
        damageButton.interactable = true;
        speedButton.interactable = true;
        armorButton.interactable = true;
    }

    public void UpgradeDamage()
    {
        if (GameManager.Instance.shellCredits >= damageCost)
        {
            GameManager.Instance.shellCredits -= damageCost;
            GameManager.Instance.bulletDamage++;
            GreyOutButton(damageButton);
            PlaySound(purchaseClip);
            UpdateCreditsText();
            Debug.Log("Damage upgraded to: " + GameManager.Instance.bulletDamage);
        }
        else
        {
            PlaySound(cantAffordClip);
            Debug.Log("Not enough credits");
        }
    }

    public void UpgradeSpeed()
    {
        if (GameManager.Instance.shellCredits >= speedCost)
        {
            GameManager.Instance.shellCredits -= speedCost;
            GameManager.Instance.bulletSpeed += 2f;
            GreyOutButton(speedButton);
            PlaySound(purchaseClip);
            UpdateCreditsText();
            Debug.Log("Speed upgraded to: " + GameManager.Instance.bulletSpeed);
        }
        else
        {
            PlaySound(cantAffordClip);
            Debug.Log("Not enough credits");
        }
    }

    public void UpgradeArmor()
    {
        if (GameManager.Instance.shellCredits >= armorCost)
        {
            GameManager.Instance.shellCredits -= armorCost;
            GameManager.Instance.maxHealth++;
            GreyOutButton(armorButton);
            PlaySound(purchaseClip);
            UpdateCreditsText();
            Debug.Log("Armor upgraded to: " + GameManager.Instance.maxHealth);
        }
        else
        {
            PlaySound(cantAffordClip);
            Debug.Log("Not enough credits");
        }
    }
}
