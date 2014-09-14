using System;
using System.Windows.Forms;
using uTank2;

internal class cs : IDisposable
{
    public eCanCastSpellDiagnosticPoint a = eCanCastSpellDiagnosticPoint.Success;
    private ev b;
    private bool c;

    public cs(ev A_0)
    {
        try
        {
            this.b = A_0;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Source + " error module: C.SpellDatabase");
        }
    }

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            this.b = null;
        }
    }

    public void a(bool A_0)
    {
    }

    public MySpell a(string A_0)
    {
        if (A_0.CompareTo("Life Magic") == 0)
        {
            return this.b.e.a("Life Magic Mastery Self I");
        }
        if (A_0.CompareTo("Melee Defense") == 0)
        {
            return this.b.e.a("Invulnerability Self I");
        }
        if (A_0.CompareTo("Missile Defense") == 0)
        {
            return this.b.e.a("Impregnability Self I");
        }
        if (A_0.CompareTo("Arcane Lore") == 0)
        {
            return this.b.e.a("Arcane Enlightenment Self I");
        }
        if (A_0.CompareTo("Magic Defense") == 0)
        {
            return this.b.e.a("Magic Resistance Self I");
        }
        if (A_0.CompareTo("Mana Conversion") == 0)
        {
            return this.b.e.a("Mana Conversion Mastery Self I");
        }
        if (A_0.CompareTo("Item Tinkering") == 0)
        {
            return this.b.e.a("Item Tinkering Expertise Self I");
        }
        if (A_0.CompareTo("Assess Person") == 0)
        {
            return this.b.e.a("Person Attunement Self I");
        }
        if (A_0.CompareTo("Deception") == 0)
        {
            return this.b.e.a("Deception Mastery Self I");
        }
        if (A_0.CompareTo("Healing") == 0)
        {
            return this.b.e.a("Healing Mastery Self I");
        }
        if (A_0.CompareTo("Jump") == 0)
        {
            return this.b.e.a("Jumping Mastery Self I");
        }
        if (A_0.CompareTo("Lockpick") == 0)
        {
            return this.b.e.a("Lockpick Mastery Self I");
        }
        if (A_0.CompareTo("Run") == 0)
        {
            return this.b.e.a("Sprint Self I");
        }
        if (A_0.CompareTo("Assess Creature") == 0)
        {
            return this.b.e.a("Monster Attunement Self I");
        }
        if (A_0.CompareTo("Weapon Tinkering") == 0)
        {
            return this.b.e.a("Weapon Tinkering Expertise Self I");
        }
        if (A_0.CompareTo("Armor Tinkering") == 0)
        {
            return this.b.e.a("Armor Tinkering Expertise Self I");
        }
        if (A_0.CompareTo("Magic Item Tinkering") == 0)
        {
            return this.b.e.a("Magic Item Tinkering Expertise Self I");
        }
        if (A_0.CompareTo("Creature Enchantment") == 0)
        {
            return this.b.e.a("Creature Enchantment Mastery Self I");
        }
        if (A_0.CompareTo("Item Enchantment") == 0)
        {
            return this.b.e.a("Item Enchantment Mastery Self I");
        }
        if (A_0.CompareTo("War Magic") == 0)
        {
            return this.b.e.a("War Magic Mastery Self I");
        }
        if (A_0.CompareTo("Leadership") == 0)
        {
            return this.b.e.a("Leadership Mastery Self I");
        }
        if (A_0.CompareTo("Loyalty") == 0)
        {
            return this.b.e.a("Fealty Self I");
        }
        if (A_0.CompareTo("Fletching") == 0)
        {
            return this.b.e.a("Fletching Mastery Self I");
        }
        if (A_0.CompareTo("Alchemy") == 0)
        {
            return this.b.e.a("Alchemy Mastery Self I");
        }
        if (A_0.CompareTo("Cooking") == 0)
        {
            return this.b.e.a("Cooking Mastery Self I");
        }
        if (A_0.CompareTo("Salvaging") == 0)
        {
            return this.b.e.a("Arcanum Salvaging Self I");
        }
        if (A_0.CompareTo("Two Handed Combat") == 0)
        {
            return this.b.e.a("Two Handed Combat Mastery Self I");
        }
        if (A_0.CompareTo("Gearcraft") == 0)
        {
            return this.b.e.a("Gear Craft Mastery Self I");
        }
        if (A_0.CompareTo("Void Magic") == 0)
        {
            return this.b.e.a("Void Magic Mastery Self I");
        }
        if (A_0.CompareTo("Heavy Weapons") == 0)
        {
            return this.b.e.a("Heavy Weapon Mastery Self I");
        }
        if (A_0.CompareTo("Light Weapons") == 0)
        {
            return this.b.e.a("Light Weapon Mastery Self I");
        }
        if (A_0.CompareTo("Finesse Weapons") == 0)
        {
            return this.b.e.a("Finesse Weapon Mastery Self I");
        }
        if (A_0.CompareTo("Missile Weapons") == 0)
        {
            return this.b.e.a("Missile Weapon Mastery Self I");
        }
        if (A_0.CompareTo("Shield") == 0)
        {
            return this.b.e.a("Shield Mastery Self I");
        }
        if (A_0.CompareTo("Dual Wield") == 0)
        {
            return this.b.e.a("Dual Wield Mastery Self I");
        }
        if (A_0.CompareTo("Recklessness") == 0)
        {
            return this.b.e.a("Recklessness Mastery Self I");
        }
        if (A_0.CompareTo("Sneak Attack") == 0)
        {
            return this.b.e.a("Sneak Attack Mastery Self I");
        }
        if (A_0.CompareTo("Dirty Fighting") == 0)
        {
            return this.b.e.a("Dirty Fighting Mastery Self II");
        }
        if (A_0.CompareTo("Summoning") == 0)
        {
            return this.b.e.a("Summoning Mastery Self I");
        }
        return MySpell.InvalidSpell;
    }

    public MySpell a(eDamageElement A_0)
    {
        switch (A_0)
        {
            case eDamageElement.Pierce:
                return this.b.e.a("Piercing Bane I");

            case eDamageElement.Bludgeon:
                return this.b.e.a("Bludgeon Bane I");

            case eDamageElement.Slash:
                return this.b.e.a("Blade Bane I");

            case eDamageElement.Acid:
                return this.b.e.a("Acid Bane I");

            case eDamageElement.Lightning:
                return this.b.e.a("Lightning Bane I");

            case eDamageElement.Cold:
                return this.b.e.a("Frost Bane I");

            case eDamageElement.Fire:
                return this.b.e.a("Flame Bane I");

            case eDamageElement.Physical:
                return this.b.e.a("Impenetrability I");
        }
        return MySpell.InvalidSpell;
    }

    public MySpell a(MySpell A_0)
    {
        return this.a(A_0, true);
    }

    public MySpell a(int A_0, bool A_1)
    {
        try
        {
            return this.a(this.b.e.b(A_0), A_1);
        }
        catch (Exception exception)
        {
            ad.a(exception);
            return MySpell.InvalidSpell;
        }
    }

    public MySpell a(string A_0, bool A_1)
    {
        try
        {
            return this.a(this.b.e.a(A_0), A_1);
        }
        catch (Exception exception)
        {
            ad.a(exception);
            return MySpell.InvalidSpell;
        }
    }

    public MySpell a(eDamageElement A_0, eCombatSpellType A_1)
    {
        MySpell invalidSpell = MySpell.InvalidSpell;
        switch (A_1)
        {
            case eCombatSpellType.Vuln:
                switch (A_0)
                {
                    case eDamageElement.Pierce:
                        return this.b.e.a("Piercing Vulnerability Other I");

                    case eDamageElement.Bludgeon:
                        return this.b.e.a("Bludgeoning Vulnerability Other I");

                    case eDamageElement.Slash:
                        return this.b.e.a("Blade Vulnerability Other I");

                    case eDamageElement.Acid:
                        return this.b.e.a("Acid Vulnerability Other I");

                    case eDamageElement.Lightning:
                        return this.b.e.a("Lightning Vulnerability Other I");

                    case eDamageElement.Cold:
                        return this.b.e.a("Cold Vulnerability Other I");

                    case eDamageElement.Fire:
                        return this.b.e.a("Fire Vulnerability Other I");

                    case eDamageElement.Harm:
                        return this.b.e.a("Drain Health Other I");

                    case eDamageElement.Auto:
                        return invalidSpell;

                    case eDamageElement.Void:
                        return this.b.e.a("Destructive Curse I");
                }
                return invalidSpell;

            case eCombatSpellType.War:
                switch (A_0)
                {
                    case eDamageElement.Pierce:
                        return this.b.e.a("Force Bolt I");

                    case eDamageElement.Bludgeon:
                        return this.b.e.a("Shock Wave I");

                    case eDamageElement.Slash:
                        return this.b.e.a("Whirling Blade I");

                    case eDamageElement.Acid:
                        return this.b.e.a("Acid Stream I");

                    case eDamageElement.Lightning:
                        return this.b.e.a("Lightning Bolt I");

                    case eDamageElement.Cold:
                        return this.b.e.a("Frost Bolt I");

                    case eDamageElement.Fire:
                        return this.b.e.a("Flame Bolt I");

                    case eDamageElement.Harm:
                        return this.b.e.a("Martyr's Hecatomb I");

                    case eDamageElement.Auto:
                        return invalidSpell;

                    case eDamageElement.Void:
                        return this.b.e.a("Nether Bolt I");
                }
                return invalidSpell;

            case eCombatSpellType.Arc:
                switch (A_0)
                {
                    case eDamageElement.Pierce:
                        return this.b.e.a("Force Arc I");

                    case eDamageElement.Bludgeon:
                        return this.b.e.a("Shock Arc I");

                    case eDamageElement.Slash:
                        return this.b.e.a("Blade Arc I");

                    case eDamageElement.Acid:
                        return this.b.e.a("Acid Arc I");

                    case eDamageElement.Lightning:
                        return this.b.e.a("Lightning Arc I");

                    case eDamageElement.Cold:
                        return this.b.e.a("Frost Arc I");

                    case eDamageElement.Fire:
                        return this.b.e.a("Flame Arc I");

                    case eDamageElement.Harm:
                        return this.b.e.a("Harm Other I");

                    case eDamageElement.Auto:
                        return invalidSpell;

                    case eDamageElement.Void:
                        return this.b.e.a("Nether Arc I");
                }
                return invalidSpell;

            case eCombatSpellType.Ring:
                switch (A_0)
                {
                    case eDamageElement.Pierce:
                        return this.b.e.a("Nuhmudira's Spines");

                    case eDamageElement.Bludgeon:
                        return this.b.e.a("Tectonic Rifts");

                    case eDamageElement.Slash:
                        return this.b.e.a("Horizon's Blades");

                    case eDamageElement.Acid:
                        return this.b.e.a("Searing Disc");

                    case eDamageElement.Lightning:
                        return this.b.e.a("Eye of the Storm");

                    case eDamageElement.Cold:
                        return this.b.e.a("Halo of Frost");

                    case eDamageElement.Fire:
                        return this.b.e.a("Cassius' Ring of Fire");

                    case eDamageElement.Harm:
                        return this.b.e.a("Curse of Raven Fury");

                    case eDamageElement.Auto:
                        return invalidSpell;

                    case eDamageElement.Void:
                        return this.b.e.b(0x14f1);
                }
                return invalidSpell;

            case eCombatSpellType.Streak:
                switch (A_0)
                {
                    case eDamageElement.Pierce:
                        return this.b.e.a("Force Streak I");

                    case eDamageElement.Bludgeon:
                        return this.b.e.a("Shock Wave Streak I");

                    case eDamageElement.Slash:
                        return this.b.e.a("Whirling Blade Streak I");

                    case eDamageElement.Acid:
                        return this.b.e.a("Acid Streak I");

                    case eDamageElement.Lightning:
                        return this.b.e.a("Lightning Streak I");

                    case eDamageElement.Cold:
                        return this.b.e.a("Frost Streak I");

                    case eDamageElement.Fire:
                        return this.b.e.a("Flame Streak I");

                    case eDamageElement.Harm:
                        return this.b.e.a("Harm Other I");

                    case eDamageElement.Auto:
                        return invalidSpell;

                    case eDamageElement.Void:
                        return this.b.e.a("Nether Streak I");
                }
                return invalidSpell;
        }
        return invalidSpell;
    }

    public MySpell a(MySpell A_0, bool A_1)
    {
        MySpell spell = null;
        eGameSkillID warMagic;
        if ((A_0 == null) || !A_0.isValid)
        {
            return null;
        }
        switch (A_0.School.Id)
        {
            case 1:
                warMagic = eGameSkillID.WarMagic;
                break;

            case 2:
                warMagic = eGameSkillID.LifeMagic;
                break;

            case 3:
                warMagic = eGameSkillID.ItemEnchantment;
                break;

            case 4:
                warMagic = eGameSkillID.CreatureEnchantment;
                break;

            case 5:
                warMagic = eGameSkillID.VoidMagic;
                break;

            default:
                throw new Exception("Wtf?");
        }
        int num = dh.a(warMagic, true);
        int quality = 0;
        foreach (MySpell spell2 in this.b.e.a(A_0.RealFamily))
        {
            if (((((spell2.School.Id == A_0.School.Id) && (spell2.Quality > quality)) && ((spell2.isFellowship == A_0.isFellowship) && (A_0.isUntargetted == spell2.isUntargetted))) && (((A_0.a().a(spell2.a()) == 0) && this.b.aw.get_CharacterFilter().IsSpellKnown(spell2.Id)) && ((num >= (spell2.Difficulty + this.b.l.a(A_1))) && spell2.HasScarabsInInventory))) && !this.b(spell2))
            {
                quality = spell2.Quality;
                spell = spell2;
            }
        }
        return spell;
    }

    public bool b()
    {
        return true;
    }

    public MySpell b(string A_0)
    {
        try
        {
            return this.a(this.b.e.a(A_0));
        }
        catch (Exception exception)
        {
            ad.a(exception);
            return MySpell.InvalidSpell;
        }
    }

    public MySpell b(eDamageElement A_0)
    {
        switch (A_0)
        {
            case eDamageElement.Pierce:
                return this.b.e.a("Piercing Protection Self I");

            case eDamageElement.Bludgeon:
                return this.b.e.a("Bludgeoning Protection Self I");

            case eDamageElement.Slash:
                return this.b.e.a("Blade Protection Self I");

            case eDamageElement.Acid:
                return this.b.e.a("Acid Protection Self I");

            case eDamageElement.Lightning:
                return this.b.e.a("Lightning Protection Self I");

            case eDamageElement.Cold:
                return this.b.e.a("Cold Protection Self I");

            case eDamageElement.Fire:
                return this.b.e.a("Fire Protection Self I");

            case eDamageElement.Physical:
                return this.b.e.a("Armor Self I");
        }
        return MySpell.InvalidSpell;
    }

    public bool b(MySpell A_0)
    {
        return (((A_0 != null) && A_0.isValid) && false);
    }

    public bool b(MySpell A_0, bool A_1)
    {
        eGameSkillID warMagic;
        switch (A_0.School.Id)
        {
            case 1:
                warMagic = eGameSkillID.WarMagic;
                break;

            case 2:
                warMagic = eGameSkillID.LifeMagic;
                break;

            case 3:
                warMagic = eGameSkillID.ItemEnchantment;
                break;

            case 4:
                warMagic = eGameSkillID.CreatureEnchantment;
                break;

            case 5:
                warMagic = eGameSkillID.VoidMagic;
                break;

            default:
                throw new Exception("Wtf?");
        }
        int num = dh.a(warMagic, true);
        if (!this.b.aw.get_CharacterFilter().IsSpellKnown(A_0.Id))
        {
            this.a = eCanCastSpellDiagnosticPoint.Fail_SpellNotInSpellbook;
            return false;
        }
        if (!A_0.HasScarabsInInventory)
        {
            this.a = eCanCastSpellDiagnosticPoint.Fail_NoScarabsInInventory;
            return false;
        }
        if (num < (A_0.Difficulty + this.b.l.a(A_1)))
        {
            this.a = eCanCastSpellDiagnosticPoint.Fail_SkillTooLow;
            return false;
        }
        if (this.b(A_0))
        {
            this.a = eCanCastSpellDiagnosticPoint.Fail_HasBannedComponent;
            return false;
        }
        this.a = eCanCastSpellDiagnosticPoint.Success;
        return true;
    }

    protected override void c()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool c(MySpell A_0)
    {
        return this.b(A_0, true);
    }

    public enum eCanCastSpellDiagnosticPoint
    {
        Fail_SpellNotInSpellbook,
        Fail_NoScarabsInInventory,
        Fail_SkillTooLow,
        Fail_HasBannedComponent,
        Success
    }
}

