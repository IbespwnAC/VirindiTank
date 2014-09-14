using System;
using System.Text.RegularExpressions;
using uTank2;

internal class d6 : IDisposable
{
    public MyList<Regex> a = new MyList<Regex>(0x61);
    public MyList<Regex> b = new MyList<Regex>(0x62);
    public MyList<Regex> c = new MyList<Regex>(0x63);
    private bool d;

    public d6()
    {
        this.a.Add(new Regex("^Your spell fizzled.$"));
        this.a.Add(new Regex("^(?<targetname>.*) resists your spell$"));
        this.a.Add(new Regex("^Target is out of range$"));
        this.a.Add(new Regex("^You fail to affect (?<targetname>.*) because you are not a player killer!$"));
        this.a.Add(new Regex("^You fail to affect (?<targetname>.*) because .* is not a player killer!$"));
        this.a.Add(new Regex("^You fail to affect (?<targetname>.*) because beneficial spells do not affect .*!$"));
        this.a.Add(new Regex("^(?<targetname>.*) is an invalid target.$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on (?<targetname>.*), refreshing .*$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on (?<targetname>.*), surpassing .*$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on (?<targetname>.*), but it is surpassed by .*$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on (?<targetname>.*)$"));
        this.b.Add(new Regex("^You .* due to casting (?<spellname>.*) on (?<targetname>.*)$"));
        this.b.Add(new Regex(@"^With (?<spellname>.*) you .* from (?<targetname>.*)\.$"));
        this.b.Add(new Regex(@"^With (?<spellname>.*) you .* to (?<targetname>.*)\.$"));
        this.b.Add(new Regex(@"^(Critical hit! )?(Sneak Attack! )?You .* .* for .* points with (?<spellname>.*)\.$"));
        this.b.Add(new Regex(@"^You cast (?<spellname>.*) and restore .* points of your .*\.$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on yourself and lose .* points of .* and also gain .* points of .*$"));
        this.b.Add(new Regex("^You have been teleported.$"));
        this.b.Add(new Regex(@"^You cast (?<spellname>.*) on (?<targetname>.*) and dispel: .*\.$"));
        this.b.Add(new Regex("^You cast (?<spellname>.*) on (?<targetname>.*), but the dispel fails.$"));
        this.c.Add(new Regex("^You knock (?<targetname>.*) into next Morningthaw!$"));
        this.c.Add(new Regex("^You obliterate (?<targetname>.*)!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is utterly destroyed by your attack!$"));
        this.c.Add(new Regex("^(?<targetname>.*) catches your attack, with dire consequences!$"));
        this.c.Add(new Regex("^The deadly force of your attack is so strong that (?<targetname>.*)'s ancestors feel it!$"));
        this.c.Add(new Regex("^You smite (?<targetname>.*) mightily!$"));
        this.c.Add(new Regex("^You slay (?<targetname>.*) viciously enough to impart death several times over!$"));
        this.c.Add(new Regex("^You killed (?<targetname>.*)!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is torn to ribbons by your assault!$"));
        this.c.Add(new Regex("^You cleave (?<targetname>.*) in twain!$"));
        this.c.Add(new Regex("^Your killing blow nearly turns (?<targetname>.*) inside-out!$"));
        this.c.Add(new Regex("^You split (?<targetname>.*) apart!$"));
        this.c.Add(new Regex("^The thunder of crushing (?<targetname>.*) is followed by the deafening silence of death!$"));
        this.c.Add(new Regex("^You beat (?<targetname>.*) to a lifeless pulp!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is shattered by your assault!$"));
        this.c.Add(new Regex("^You flatten (?<targetname>.*)'s body with the force of your assault!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is fatally punctured!$"));
        this.c.Add(new Regex("^(?<targetname>.*)'s perforated corpse falls before you!$"));
        this.c.Add(new Regex("^You run (?<targetname>.*) through!$"));
        this.c.Add(new Regex("^(?<targetname>.*)'s death is preceded by a sharp, stabbing pain!$"));
        this.c.Add(new Regex("^You bring (?<targetname>.*) to a fiery end!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is incinerated by your assault!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is reduced to cinders!$"));
        this.c.Add(new Regex("^(?<targetname>.*)'s seared corpse smolders before you!$"));
        this.c.Add(new Regex("^Your lightning coruscates over (?<targetname>.*)'s mortal remains!$"));
        this.c.Add(new Regex("^Blistered by lightning, (?<targetname>.*) falls!$"));
        this.c.Add(new Regex("^Electricity tears (?<targetname>.*) apart!$"));
        this.c.Add(new Regex("^Your assault sends (?<targetname>.*) to an icy death!$"));
        this.c.Add(new Regex("^Your attack stops (?<targetname>.*) cold!$"));
        this.c.Add(new Regex("^(?<targetname>.*) suffers a frozen fate!$"));
        this.c.Add(new Regex("^(?<targetname>.*)'s last strength dissolves before you!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is liquified by your attack!$"));
        this.c.Add(new Regex("^You reduce (?<targetname>.*) to a sizzling, oozing mass!$"));
        this.c.Add(new Regex("^You reduce (?<targetname>.*) to a drained, twisted corpse!$"));
        this.c.Add(new Regex("^(?<targetname>.*) is dessicated by your attack!$"));
        this.c.Add(new Regex("^(?<targetname>.*)'s last strength withers before you!$"));
    }

    public void a()
    {
        if (!this.d)
        {
            this.d = true;
            GC.SuppressFinalize(this);
        }
    }

    protected override void b()
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
}

