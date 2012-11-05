using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDocumentSystem.Models;
using BusinessObjects;


namespace WebDocumentSystem.Document
{
    public partial class SuperSecretDeleteMeFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using ( WebDocEntities ctx = new WebDocEntities())
            {
                Random rnd = new Random();
                byte[] b = new byte[4096];


                var AdminRole = new Models.UserType();
                AdminRole.Type = "Admin";

                var UserJeremy = new Models.User();
                UserJeremy.Name = "jwright";
                UserJeremy.Password = "hello";
                UserJeremy.UserType = AdminRole;
                

                var request = new AccountRequest();
                request.PasswordStrength = (int)PasswordAdvisor.CheckStrength(UserJeremy.Password);

                request.User = UserJeremy;

                var SecQuestion = new Models.SecurityQuestions();
                SecQuestion.Question = "What is your quest?";
                UserJeremy.SecurityQuestion = SecQuestion;

                UserJeremy.SecurityAnswer = "Holy Grail.";

                ctx.Users.AddObject(UserJeremy);
                ctx.SaveChanges();

                for (var i = 0; i < 20; ++i)
                {
                    var document = new Models.Document();
                    document.Name = "Document_" + i;
                    document.Owner = UserJeremy;
                    
                    // Create 15 random versions.
                    for (int j = 0; j < 15; ++j)
                    {
                        var documentData = new Models.DocumentData();
                        document.Revision = documentData.Id;
                        rnd.NextBytes(b);
                        documentData.DocContent = b;
                        document.DocumentDatas.Add(documentData);

                    }
                    ctx.Documents.AddObject(document);
                }
                ctx.SaveChanges();

                foreach(var document in ctx.Documents)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        var note = new Models.DocumentNote();
                        note.Note = random_notes[rnd.Next(random_notes.Length)];
                        note.User = UserJeremy;
                        document.DocumentNotes.Add(note);

                    }
                }

                ctx.SaveChanges();
                
                
                
            }
        }

        protected string[] random_notes = {"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
"Nam nec urna at orci sagittis gravida eget id odio.",
"Aenean commodo nulla vitae quam dapibus viverra.",
"Aenean pretium convallis nulla, a posuere nibh mollis vitae.",
"Ut id tellus eu est aliquet scelerisque at eu urna.",
"Nunc fermentum laoreet dui, non rutrum ipsum congue scelerisque.",
"Quisque ut leo in dui ultricies facilisis.",
"Integer et lorem in enim euismod placerat.",
"Sed et eros ante, sed adipiscing magna.",
"Aliquam auctor quam enim, id condimentum turpis.",
"Integer egestas tortor a diam consectetur mollis semper tortor hendrerit.",
"Nunc in lectus non risus porttitor tristique.",
"Praesent faucibus auctor mi, nec vestibulum odio vulputate nec.",
"Nunc eu quam massa, et ullamcorper nulla.",
"Donec semper lorem id arcu auctor viverra.",
"Mauris a risus turpis, a volutpat libero.",
"Fusce nec nisi id magna vulputate pharetra eu ac nulla.",
"Duis fringilla massa non elit ultrices molestie.",
"Curabitur a nisl luctus risus lacinia aliquam.",
"Aenean dapibus imperdiet lorem, eget sollicitudin nisl lobortis ac.",
"Donec varius massa imperdiet nibh ultricies vitae laoreet urna sagittis.",
"Quisque congue fringilla elit, id pretium libero commodo vel.",
"Etiam nec risus ac mauris ultrices lacinia.",
"Pellentesque pulvinar est quis enim imperdiet non accumsan urna auctor.",
"Ut non ante at enim egestas lacinia sit amet in ligula.",
"Phasellus et lorem nisl, vel venenatis ligula.",
"Aliquam id mauris quis risus ultricies aliquet in non orci.",
"Cras a tellus vel enim iaculis ultrices.",
"Morbi et felis eget velit vestibulum imperdiet.",
"Sed lobortis nibh vitae risus accumsan sodales.",
"Curabitur ullamcorper dignissim enim, eu condimentum ante euismod eget.",
"Donec vitae ante sit amet lacus consequat tristique.",
"Ut nec enim vel nunc auctor porta sed sed lectus.",
"Nullam tincidunt dui a nunc laoreet accumsan.",
"Sed posuere tortor id enim vestibulum porttitor.",
"Ut sit amet libero vel neque consequat imperdiet.",
"Nulla nec elit et mauris dapibus dictum a vel augue.",
"Etiam vehicula quam ut felis aliquet porta.",
"Nam volutpat tortor vitae elit lobortis a mattis diam consequat.",
"Cras non turpis nulla, consectetur vehicula orci.",
"Donec eget neque eu tortor tempor vestibulum.",
"Nunc vehicula felis sed dui lacinia iaculis.",
"Sed tempus metus porttitor lorem molestie dapibus auctor nulla faucibus.",
"Cras quis nunc nec sapien auctor vehicula.",
"Pellentesque adipiscing mauris vitae nunc mattis volutpat.",
"Cras venenatis massa eget sapien ultrices non dapibus ligula adipiscing.",
"Fusce sit amet dolor lacus, non rhoncus dui.",
"Nulla eu libero eu est viverra dapibus faucibus at mi.",
"Integer iaculis justo a lorem mattis ornare.",
"Phasellus ut enim elit, nec vehicula elit.",
"Aliquam at neque sit amet dolor vestibulum volutpat.",
"Ut gravida velit in tortor sollicitudin mollis.",
"Sed fermentum massa a neque interdum blandit.",
"Donec sodales nisl ac neque facilisis eu vulputate nibh faucibus.",
"Aliquam id enim et leo ornare consequat eget sit amet libero.",
"Nam pretium nibh vitae tellus sagittis pellentesque.",
"Ut aliquam cursus magna, pulvinar pharetra orci rutrum id.",
"Donec gravida enim vel erat faucibus vestibulum.",
"Cras pellentesque dolor id magna gravida in sagittis velit ultrices.",
"Sed ac arcu non metus ornare ornare ut et dolor.",
"Sed non ante tellus, a scelerisque augue.",
"Nunc ut eros sed arcu lobortis lacinia vel vel neque.",
"Vivamus eu purus sed tellus lobortis convallis at et arcu.",
"Sed ullamcorper dolor quis libero congue quis imperdiet ante pretium.",
"Donec et mi vel velit hendrerit dictum.",
"Etiam et arcu in risus suscipit tempor a id sapien.",
"Sed vel mi a velit laoreet iaculis.",
"Praesent pretium tellus ac nibh tincidunt sit amet dignissim libero vehicula.",
"Suspendisse at ligula ac dui accumsan porta.",
"Mauris sit amet neque ante, eu eleifend quam.",
"Duis at odio magna, id auctor ipsum.",
"Praesent nec elit orci, in aliquam massa.",
"Praesent non dolor magna, vel iaculis justo.",
"Mauris varius consequat quam, sit amet elementum ante auctor a.",
"Vestibulum malesuada arcu non purus vestibulum molestie.",
"Suspendisse consectetur erat eu est consequat quis semper tortor fringilla.",
"Aenean nec risus purus, eu placerat sem.",
"In a eros vitae neque commodo vestibulum vel nec elit.",
"Proin in lacus tortor, ac feugiat quam.",
"Duis quis urna tortor, quis mollis ante.",
"Fusce pharetra cursus lectus, id sodales lorem egestas vitae.",
"Vestibulum interdum consequat felis, non accumsan enim fringilla id.",
"Sed quis quam odio, in varius metus.",
"Etiam consequat dolor et nisl volutpat vitae pharetra felis vehicula.",
"Duis scelerisque pretium magna, et faucibus metus condimentum vel.",
"Integer sed sapien arcu, et tristique elit.",
"Proin consequat est at augue tincidunt tristique.",
"Etiam lobortis sem vel odio scelerisque ultricies.",
"Donec sed est vel metus laoreet accumsan.",
"Proin in augue vitae ante consequat ultricies.",
"Ut fringilla metus vitae urna bibendum aliquet in eu lectus.",
"Maecenas ornare porta purus, sed volutpat justo lacinia et.",
"Curabitur fermentum nibh sagittis nulla sodales tristique non sed magna.",
"Nam eu diam ut nisi semper aliquam eu nec massa.",
"Phasellus rhoncus nisl nec massa porta tincidunt sed quis velit.",
"Aliquam sed urna arcu, et blandit elit.",
"Duis sit amet neque turpis, ac luctus sapien.",
"In quis leo elit, in mollis elit.",
"Suspendisse sed justo et magna molestie scelerisque.",
"Nullam porta consectetur mi, vel faucibus nisi sollicitudin et.",
"Vivamus ut sem eget nulla dictum luctus.",
"Donec dignissim cursus nunc, quis suscipit sem viverra nec.",
"Donec eu ipsum et nibh cursus varius eget eget sem.",
"Nunc bibendum auctor ipsum, sit amet placerat ante laoreet sed.",
"Ut convallis tincidunt enim, sit amet pharetra risus laoreet quis.",
"Cras pretium facilisis eros, ac vestibulum nibh convallis imperdiet.",
"Nullam a sapien id ligula faucibus tincidunt.",
"Vestibulum adipiscing turpis ut quam posuere suscipit.",
"Vivamus in leo id lacus pellentesque scelerisque id non ipsum.",
"Etiam malesuada nisi id nulla malesuada commodo et non nisl.",
"Mauris in mi sit amet magna tincidunt euismod.",
"Maecenas sit amet nulla iaculis sapien feugiat commodo nec sed lectus.",
"Nam et augue sit amet elit luctus auctor id id magna.",
"Curabitur vestibulum nunc nec nibh iaculis id condimentum lacus ornare.",
"Pellentesque accumsan felis vitae urna condimentum et fermentum nulla lacinia.",
"Etiam non elit vel elit dapibus venenatis.",
"Phasellus in urna sed nunc imperdiet pretium.",
"Aenean ut mi et nisl sollicitudin venenatis nec sed felis.",
"Nullam bibendum turpis sit amet sem vestibulum iaculis.",
"Nam at ligula at lectus lobortis condimentum.",
"Nam dictum adipiscing tellus, vitae ornare erat pharetra aliquam.",
"Donec tempor quam pretium ligula iaculis id viverra libero congue.",
"Sed gravida ornare dui, eu cursus massa dapibus nec.",
"Praesent ut diam sit amet dui porta elementum.",
"Donec posuere urna eget risus fringilla bibendum iaculis ligula tristique.",
"Cras a justo quam, at feugiat magna.",
"Morbi blandit mauris vitae nunc aliquet sit amet tristique urna malesuada.",
"Cras id enim eu ligula mattis placerat.",
"Fusce nec lectus vel magna aliquet adipiscing at ac mauris.",
"Etiam lacinia massa ante, ac ultricies dolor.",
"Praesent ac dolor ut nibh facilisis venenatis quis nec neque.",
"Praesent et nibh a lacus viverra suscipit.",
"Phasellus pellentesque felis id eros condimentum dictum.",
"Morbi at massa nibh, sit amet semper purus.",
"Nulla vulputate urna sit amet libero viverra mollis.",
"Sed vel eros nec felis venenatis eleifend sit amet egestas justo.",
"Cras luctus risus ac mi vestibulum bibendum.",
"In dictum metus vel arcu consequat sit amet pretium nisi eleifend.",
"Maecenas in enim quis urna pretium ornare a nec tortor.",
"Mauris id odio eget mauris semper semper.",
"Fusce non risus sit amet massa tempus lacinia.",
"Nunc non ipsum neque, eget feugiat elit.",
"Fusce vel leo a felis adipiscing interdum sollicitudin non quam.",
"Maecenas sit amet nunc sit amet neque fringilla cursus.",
"Fusce et dolor eget velit dictum tempor.",
"Nullam eu mauris nisl, eu imperdiet nisi.",
"Curabitur non massa ut lacus mattis suscipit.",
"Quisque convallis nisi eget nisl dignissim ut congue ante molestie.",
"Morbi vitae odio elit, aliquam aliquet ante.",
"Nullam vitae arcu tortor, non vehicula diam.",
"Proin congue neque eu augue feugiat et vestibulum metus volutpat.",
"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
"Nam nec urna at orci sagittis gravida eget id odio.",
"Aenean commodo nulla vitae quam dapibus viverra.",
"Aenean pretium convallis nulla, a posuere nibh mollis vitae.",
"Ut id tellus eu est aliquet scelerisque at eu urna.",
"Nunc fermentum laoreet dui, non rutrum ipsum congue scelerisque.",
"Quisque ut leo in dui ultricies facilisis.",
"Integer et lorem in enim euismod placerat.",
"Sed et eros ante, sed adipiscing magna.",
"Aliquam auctor quam enim, id condimentum turpis.",
"Integer egestas tortor a diam consectetur mollis semper tortor hendrerit.",
"Nunc in lectus non risus porttitor tristique.",
"Praesent faucibus auctor mi, nec vestibulum odio vulputate nec.",
"Nunc eu quam massa, et ullamcorper nulla.",
"Donec semper lorem id arcu auctor viverra.",
"Mauris a risus turpis, a volutpat libero.",
"Fusce nec nisi id magna vulputate pharetra eu ac nulla.",
"Duis fringilla massa non elit ultrices molestie.",
"Curabitur a nisl luctus risus lacinia aliquam.",
"Aenean dapibus imperdiet lorem, eget sollicitudin nisl lobortis ac.",
"Donec varius massa imperdiet nibh ultricies vitae laoreet urna sagittis.",
"Quisque congue fringilla elit, id pretium libero commodo vel.",
"Etiam nec risus ac mauris ultrices lacinia.",
"Pellentesque pulvinar est quis enim imperdiet non accumsan urna auctor.",
"Ut non ante at enim egestas lacinia sit amet in ligula.",
"Phasellus et lorem nisl, vel venenatis ligula.",
"Aliquam id mauris quis risus ultricies aliquet in non orci.",
"Cras a tellus vel enim iaculis ultrices.",
"Morbi et felis eget velit vestibulum imperdiet.",
"Sed lobortis nibh vitae risus accumsan sodales.",
"Curabitur ullamcorper dignissim enim, eu condimentum ante euismod eget.",
"Donec vitae ante sit amet lacus consequat tristique.",
"Ut nec enim vel nunc auctor porta sed sed lectus.",
"Nullam tincidunt dui a nunc laoreet accumsan.",
"Sed posuere tortor id enim vestibulum porttitor.",
"Ut sit amet libero vel neque consequat imperdiet.",
"Nulla nec elit et mauris dapibus dictum a vel augue.",
"Etiam vehicula quam ut felis aliquet porta.",
"Nam volutpat tortor vitae elit lobortis a mattis diam consequat.",
"Cras non turpis nulla, consectetur vehicula orci.",
"Donec eget neque eu tortor tempor vestibulum.",
"Nunc vehicula felis sed dui lacinia iaculis.",
"Sed tempus metus porttitor lorem molestie dapibus auctor nulla faucibus.",
"Cras quis nunc nec sapien auctor vehicula.",
"Pellentesque adipiscing mauris vitae nunc mattis volutpat.",
"Cras venenatis massa eget sapien ultrices non dapibus ligula adipiscing.",
"Fusce sit amet dolor lacus, non rhoncus dui.",
"Nulla eu libero eu est viverra dapibus faucibus at mi.",
"Integer iaculis justo a lorem mattis ornare.",
"Phasellus ut enim elit, nec vehicula elit.",
"Aliquam at neque sit amet dolor vestibulum volutpat.",
"Ut gravida velit in tortor sollicitudin mollis.",
"Sed fermentum massa a neque interdum blandit."};

    }
}