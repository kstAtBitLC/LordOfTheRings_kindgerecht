using LordOfTheRings_kindgerecht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LordOfTheRings_kindgerecht {

    class Program {
        static void Main ( string [] args ) {
            Hobbit hobbit = new Hobbit () { Name = "Frodo" };
            Ring derEine = new Ring () { NameDesRings = "Der Eine" };

            hobbit.ZauberRingHandler_Nr1 += derEine.SetUnsichtbar;
            hobbit.ZauberRingHandler_Nr2 += derEine.SetSichtbar;

            hobbit.Laufherum ();
            Console.ReadLine ();
        }
    }

    class Hobbit {
        public event EventHandler<EventArgs> ZauberRingHandler_Nr1;
        public event EventHandler<EventArgs> ZauberRingHandler_Nr2;

        public string Name { get; set; }
        private bool sichtbar;
        public int Verlangen { get; set; } = 0;
        private Random zfg = new Random ();

        public void SetUnsichtbar () {
            this.sichtbar = false;
            Console.WriteLine ("Bin nicht zu sehen");
        }
        public void SetSichtbar () {
            this.sichtbar = true;
            Console.Write ("Bin zu sehen ...");
        }

        public void Laufherum () {
            for ( int i = 0 ; i < 100 ; i++ ) {
                Verlangen = zfg.Next ( 0, 11 );
                Thread.Sleep (500);

                if ( Verlangen > 8 ) {
                    Console.WriteLine ("Verlangen ist > 8");
                    ZauberRingHandler_Nr1 ( this, EventArgs.Empty );
                } else {
                    ZauberRingHandler_Nr2 ( this, EventArgs.Empty );
                }
            }
        }
    }
}


class Ring {
    public string NameDesRings { get; set; }

    public void SetUnsichtbar ( object o, EventArgs e ) {
        if ( o != null ) {
            Console.WriteLine ("Ich - {0} - mache den Hobbit namens {1} unsichtbar", this.NameDesRings, ( ( Hobbit ) o ).Name );
            ( ( Hobbit ) o ).SetUnsichtbar ();
        }
    }

    public void SetSichtbar ( object o, EventArgs e ) {
        if ( o != null ) {
            Console.WriteLine ("Schade - {0} wurde soeben von {1} abgenommen",this.NameDesRings, ( ( Hobbit ) o ).Name );
            ( ( Hobbit ) o ).SetSichtbar ();
        }
    }
} 
    
