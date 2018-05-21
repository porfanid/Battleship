using System;
using System.Diagnostics;
namespace ConsoleApp1
{
    class StartUpAnimation
    {
        public String[] startUpText = {
            "[!]:./action.SYSTEM.BOOT",
            "efiboot loaded from device: Acpi(PNP0A03,0)/Pci(1C|4)/Pci(0|0)/SATA0,",
            "SATA1,SATA2,SATA3, SigE01574-16D9-4F98-8D56488F7CCCC8)",
            "boot file path: \\System\\CoreServicesLibrary\\phx1\\tiny\\bootefil.efi",
            "",
            ".........................",
            "..........",
            ".........................................................",
            ".........................................................",
            ".........................................................",
            ".........................................................",
            "...........................",
            ".",
            ".",
            ".",
            ".",
            ".........",
            ".........",
            "....................................",
            ".........................................................",
            ".........................................................",
            "Administrator Supervisory Mode Executive Protection running",
            "Kernel Version 39.7.0: Day 0:",
            "vm_page_bootstrap: 4045336795451 free pages and 116200725 wired pages",
            "extensions submap [0xffffffff7f800a00000f - [0xfffffffb0000000000000]",
            "",
            "zone leak detection		enabled",
            "corruption leak detection	enabled",
            "distributed leak detection	enabled",
            "",
            "\"vm_compresser_mode\" is unlimited",
            "multi scheduler config: deep-drain 0, depth limit=unlimited",
            "standard timeslicing quantum is 10 uSec",
            "standard background quantum is 25 uSec",
            "con-cmd_table_max_displ = 999",
            "Deadline Timer variables supported and enabled",
            "calling mpo_policy_init for Sandbox",
            "Security policy loaded: Safety net for Sandbox",
            "calling mpo_policy_init for CPU_distro_PS3",
            "Security policy loaded: Safety net for CPU_distro_PS3",
            "calling mpo_policy_init for Seatbelt",
            "Security policy loaded: Seatbelt for CPU_distro_PS3",
            "calling mpo_policy_init for Quarantine",
            "Security policy loaded: Quarantine for CPU_distro_PS3",
            "Security Framework successfully initialized",
            "",
            "",
            "",
            "PhxACPICPU ProcessorId=1 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=2 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=3 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=4 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=5 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=6 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=7 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=8 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=9 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=10 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=11 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=12 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=13 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=14 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=15 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=16 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=17 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=18 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=19 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=20 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=21 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=22 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=23 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=24 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=25 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=26 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=27 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=28 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=29 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=30 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=31 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=32 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=33 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=34 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=35 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=36 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=37 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=38 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=39 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=40 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=41 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=42 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=43 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=44 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=45 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=46 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=47 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=48 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=49 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=50 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=51 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=52 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=53 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=54 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=55 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=56 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=57 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=58 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=59 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=60 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=61 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=62 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=63 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=64 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=65 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=66 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=67 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=68 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=69 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=70 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=71 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=72 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=73 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=74 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=75 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=76 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=77 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=78 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=79 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=80 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=81 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=82 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=83 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=84 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=85 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=86 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=87 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=88 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=89 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=90 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=91 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=92 LocalApicId=6 Enabled Starting---",
            "PhxACPICPU ProcessorId=93 LocalApicId=1 Enabled Starting---",
            "PhxACPICPU ProcessorId=94 LocalApicId=3 Enabled Starting---",
            "PhxACPICPU ProcessorId=95 LocalApicId=5 Enabled Starting---",
            "PhxACPICPU ProcessorId=96 LocalApicId=7 Enabled Starting---",
            "PhxACPICPU ProcessorId=97 LocalApicId=0 Enabled Starting---",
            "PhxACPICPU ProcessorId=98 LocalApicId=2 Enabled Starting---",
            "PhxACPICPU ProcessorId=99 LocalApicId=4 Enabled Starting---",
            "PhxACPICPU ProcessorId=100 LocalApicId=6 Enabled Starting---",
            "PhxA"
    };

        public String[] loadingComponents = {
            "LOADING BATTLESHIP.STARTUPANIMATION",

            "LOADING CORE FUNCTIONALITY",
            "LOADING BATTLESHIP MAINPAGE",
            "LOADING BATTLESHIP CLASSES",

            "INITIALIZING LOCAL FUNCTIONALITY",
            "LOADING BATTLESHIP.FILE EXTENSION",
            "LOADING BATTLESHIP.HUMAN PLAYER",
            "LOADING BATTLESHIP.COMPUTER PLAYER",


            "LOADING PRE-EXISTING FACIAL DATA",
            "LOADING BATTLESHIP.FACE",
            "LOADING BATTLESHIP.RECOGNITIONMODE",

            "LOADING HIGHER-ORDER FUNCTIONS",
            "LOADING BATTLESHIP.FACIALDETECTION",
            "LOADING BATTLESHIP.FACIALRECOGNITION",

            "LOADING UI ELEMENTS",
            "FINALIZING BOOT SEQUENCE"
    };










        private void wait(int milliseconts)
        {
            try
            {
                System.Threading.Thread.Sleep(milliseconts);
            }
            catch (Exception)
            {

            }
        }






        public void createStartUpAnimation()
        {
            Mail paul = new Mail();
            paul.info();
            SlowPrint Slow = new SlowPrint();

            Console.Clear();

            GetLocation test = new GetLocation();
            test.GetLocationProperty();


            wait(3000);

            try
            {
                Slow.Print("FANCY MODE ACTIVATED...");
            }
            catch (Exception)
            {

            }

            wait(3000);

            Console.Clear();

            wait(3000);

            try
            {
                Slow.Print("INITIATING BOOT SEQUENCE...");
            }
            catch (Exception)
            {

            }

            wait(3000);

            Console.Clear();

            wait(3000);

            foreach (String s in startUpText)
            {
                Console.Write(s);
                Console.Write("\n");
                wait(50);
            }










            wait(3000);

            Console.Clear();

            wait(3000);

            try
            {
                Slow.Print("LOADING COMPONENTS...");
            }
            catch (Exception)
            {

            }

            wait(3000);

            foreach (String s in loadingComponents)
            {
                Console.Write(s);
                Console.Write("\n");
                wait(50);
            }



            wait(3000);
            Console.Clear();

            Process[] processlist = Process.GetProcesses();
            Console.WriteLine("LOADING THE PROCESSES CURRENTLY RUNNING");
            wait(3000);
            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                wait(50);
            }






            wait(3000);

            try
            {
                Slow.Print("BOOT SEQUENCE COMPLETE...");
                Console.Write("\n");
                Console.Write("STARTING THE BATTLESHIP...");
            }
            catch (Exception)
            {

            }

            wait(3000);



            Console.Clear();

            wait(3000);

        }    //    Console.Clear();
    }
}
