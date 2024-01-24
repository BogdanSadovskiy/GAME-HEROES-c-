
using System;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace myGame;




class program
{
    static void Main(string[] args)
    {

        List<Artefact> artefacts_LVL1= new List<Artefact>();
        artefacts_LVL1.Add(new Broom_Handle());
        artefacts_LVL1.Add(new Occult_Bracelet());
        artefacts_LVL1.Add(new Philosopher_s_Stone());
        List<Artefact> artefacts_LVL2 = new List<Artefact>();
        artefacts_LVL2.Add(new Eternal_Shroud());
        artefacts_LVL2.Add(new Daedalus());
        artefacts_LVL2.Add(new Octarine_Core());
        artefacts_LVL2.Add(new Radiance());
        artefacts_LVL2.Add(new Vanguard());
        artefacts_LVL2.Add(new Butterfly());
        artefacts_LVL2.Add(new Blade_Mail());

        artefacts_LVL1.Sort((Artefact a, Artefact b) => a.price.CompareTo(b.price));
        artefacts_LVL2.Sort((Artefact a, Artefact b) => a.price.CompareTo(b.price)); // sorting using lambda 
        //artefacts lvl2

        
        while(GameProccess.GAME( artefacts_LVL1, artefacts_LVL2)){ }
   
    }
}