using UnityEngine;

public class PProperties : MonoBehaviour
{
    #region Статы перса

    [Header("Статы персонажа")]
    public int level = 1;
    public float health = 100;
    public float protection = 1;
    public float walkSpeed = 1;
    public float chanceCritDamage = 1;
    public float critDamage = 1;
    public bool secondChance = false;
    #endregion

    #region Статы оружия
    [Header("Статы оружия")]
    public float attackSpeed = 1;
    public float damage;
    public bool canAcross;
    public bool canRicochet;
    public bool canSplash;
    #endregion

    #region Иннициализация всех SO

    [Header("Сюда кидать ассеты персонажей")]
    [SerializeField] private PStatistics_SO[] pStats_SO;
    public int indexCharacter;

    [Header("Сюда кидать ассеты оружия")]
    [SerializeField] private Arrows_SO[] arrowsProperties_SO;
    public int indexArrow;

    [Header("Сюда кидать ассеты броньки")]
    [SerializeField] private Armor_SO[] armor_SO;
    public int indexArmor;

    [Header("Сюда кидать ассеты артифактов")]
    [SerializeField] private Artifacts_SO[] artifacts_SO;
    public int indexArtifact;

    [Header("Сюда кидать ассеты ботинок")]
    [SerializeField] private Boots_SO[] boots_SO;
    public int indexBoots;

    #endregion

    private void Awake()
    {
        TakeProp();
    }

    public void TakeProp()
    {
        #region Добавление стат из SO перса

        level = pStats_SO[indexCharacter].level;
        health = pStats_SO[indexCharacter].health;
        protection = pStats_SO[indexCharacter].protection;
        walkSpeed = pStats_SO[indexCharacter].walkSpeed;
        chanceCritDamage = pStats_SO[indexCharacter].chanceCritDamage;
        critDamage = pStats_SO[indexCharacter].critDamage;
        secondChance = pStats_SO[indexCharacter].secondChance;

        #endregion

        #region Добавление стат из SO оружий

        attackSpeed = arrowsProperties_SO[indexArrow].AttackSpeed;
        damage = arrowsProperties_SO[indexArrow].Damage;
        canAcross = arrowsProperties_SO[indexArrow].canAcross;
        canRicochet = arrowsProperties_SO[indexArrow].canRicochet;
        canSplash = arrowsProperties_SO[indexArrow].canSplash;

        #endregion

        #region Добавление параметров из шмоток

        health += boots_SO[indexBoots].healthUp;
        protection += armor_SO[indexArmor].protection + boots_SO[indexBoots].protection;
        walkSpeed += armor_SO[indexArmor].speedUp + boots_SO[indexBoots].speedUp;
        damage += artifacts_SO[indexArtifact].damageUp;
        critDamage += artifacts_SO[indexArtifact].critUp;

        #endregion
    }

    public void HealthUp()
    {
        health *= 1.3f;
    }
    public void DamageUp()
    {
        damage *= 1.2f;
    }
    public void SpeedUp()
    {
        walkSpeed += 2;
    }
}