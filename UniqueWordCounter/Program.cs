using System.IO;
using System.Text;
using UniqueWordCounter.Control;
using UniqueWordCounter.IO;
using UniqueWordCounter.IO.Format;
using UniqueWordCounter.Models.Data;
using UniqueWordCounter.Models.Repo;
using UniqueWordCounter.Service;
using UniqueWordCounter.View;

string loadPath = @"D:\TestEnvironment\bunin_i_a-text_2262.fb2";
string savePath = @"D:\TestEnvironment\test.txt";

// Create serializations class
Dictionary<string, IDeserializator> listInputFormats = new();
listInputFormats.Add(".fb2", new Fb2());
listInputFormats.Add(".txt", new Txt());
Dictionary<string, ISerializator> listOutputFormats = new();
listOutputFormats.Add(".txt", new Txt());

// Initiations modules
FormatRepo formatRepo = new(listInputFormats, listOutputFormats);
HashWordRep wordRep = new();
WRepManager repManager = new(wordRep);
ConsoleView view = new();
InnerData data = new();
Reader loader = new(data);
FileSaver saver = new(repManager);
WordCounter wcounter = new(data, repManager) ;
ProgramCtrl pc = new(formatRepo, wcounter, loader, saver, view);

// Program running
bool run = true;
int startMenu = 1;
int cursor = startMenu;
int max = 8;
bool openKeys = false;
string path = string.Empty;
string optionMsg = string.Empty;

while (run)
{
    if (cursor > max || cursor < 0) cursor = 1;

    switch(cursor)
    {
        case 0:
            {
                run = pc.Quit();
                break;
            }
        case 1:
            { 
                optionMsg = ViewMessage.INTRO;
                openKeys = true;
                break;
            } 
        case 2:
            {
                view.Message(ViewMessage.LOAD_FILE);
                if(pc.GetInputString(out path))
                    cursor++;
                break;
            }
        case 3:
            {
                if (pc.LoadFile(path))
                    cursor++;
                else
                    cursor--;
                break;
            }
        case 4:
            {
                view.Message(ViewMessage.START_WC);
                if (pc.Calc())
                    cursor++;
                else
                    cursor = 1;
                break;
            }
        case 5:
            {
                optionMsg = ViewMessage.TO_DO;
                openKeys = true;
                break;
            }
        case 6:
            {
                view.Message(ViewMessage.SAVE_FILE);
                if(pc.GetInputString(out path)) 
                    cursor++;
                break;
            }
        case 7:
            {
                if (pc.SaveResult(path))
                    cursor++;
                else
                    cursor -= 2;
                break;
            }
        case 8:
            {
                optionMsg = ViewMessage.REPEAT;
                openKeys = true;
                break;
            }
        default: 
            break;
    }

    if (openKeys)
    {
        view.Message(optionMsg);
        ConsoleKey key = Console.ReadKey().Key;

        switch (key)
        {
            case ConsoleKey.D1: cursor++; break;
            case ConsoleKey.D0: run = pc.Quit(); break;
            default: break;
        }
        openKeys = false;
    }
}
view.Message(ViewMessage.BYE);


/*while (run)
{
    view.Message(ViewMessage.INTRO);
    var key = Console.ReadKey().Key;
    if (key == ConsoleKey.D1)
    {
        string path;
        do
        {
            do
            {
                view.Message(ViewMessage.LOAD_FILE);
            }
            while (!pc.GetInputString(out path));
        }
        while (!pc.LoadFile(path));

        do
        {
            view.Message(ViewMessage.START_WC);
        }
        while (!pc.Calc());

        view.Message(ViewMessage.TO_DO);

        key = Console.ReadKey().Key;

        if (key == ConsoleKey.D1)
        {
            view.Message(repManager.MostCommon().ToString());
        }

        if (key == ConsoleKey.D2)
        {
            do
            {
                do
                {
                    view.Message(ViewMessage.SAVE_FILE);
                }
                while (!pc.GetInputString(out path));
            }
            while (!pc.SaveResult(path));
        }

        view.Message(ViewMessage.REPEAT);

        key = Console.ReadKey().Key;

        if (key == ConsoleKey.D2)
        {
            run = false;
        }
    }
    view.Message(ViewMessage.BYE);
}*/
/*pc.LoadFile(loadPath);
pc.Calc();
pc.SaveResult(savePath);
*/

//@"D:\TestEnvironment\bunin_i_a-text_2262.fb2"
//innerData.Texts.Select(e => e).ToList().ForEach(e => Console.WriteLine(e));

// repManager.Import("desc", innerData)
// innerData.QWords.Select(e => { Console.WriteLine(e.Value); return true; });
// Console.WriteLine(wordRep.Length);

/*
 * Repository
 * Service
 * Logger
 * View
 * Controller
 * Data
 * 
*/