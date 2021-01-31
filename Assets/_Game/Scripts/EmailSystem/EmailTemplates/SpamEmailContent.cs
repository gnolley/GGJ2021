using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.Content {
    public class SpamEmailContent : MonoBehaviour {

        [SerializeField] private Sprite[] authorSprites = new Sprite[3];

        private List<Author> SpamAuthors = new List<Author>();

        private List<SpamEmail> spamEmails = new List<SpamEmail>();
            
        public void Populate() {
            PopulateAuthors();
            PopulareEmails();
        }

        void PopulateAuthors() {
            SpamAuthors.Add(new Author(authorSprites[0], "TEEE EM ZEE", "noreply@teeemzeeman.com"));
            SpamAuthors.Add(new Author(authorSprites[1], "Diddle Dudley", "dudley@sleepwithsinglebeds.com"));
            SpamAuthors.Add(new Author(authorSprites[2], "Eric Legit", "eric@leigt.com"));
        }

        public SpamEmail GetRandomContent() {
            return spamEmails[Random.Range(0, spamEmails.Count)];
        }

        void PopulareEmails() {
            spamEmails.Add(new SpamEmail(SpamAuthors[0], "Lindsay Lohan, where is she now?", "Click the link below to read how Lindsay Lohan got cast as Jiminy Cricket in Disney's new Broadway musical Pinocchio 2: The Fall of the Toy Maker's Creation."));
            spamEmails.Add(new SpamEmail(SpamAuthors[0], "Pope Francis converts to Scientology?!", "Pope Francis has revealed the bizarre reason that he has converted to Scientology. Click the link below to read more!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[0], "Nicholas Cage mistakes a naked mole rat for Judi Dench!", "Learn how Judi Dench ordered that Nicholas Cage be blackballed from Hollywood after he told a naked mole rat that the creature was awful in the film Cats on live television. Click the link below."));
            spamEmails.Add(new SpamEmail(SpamAuthors[0], "Paul Hogan signs deal for 23 more Crocodile Dundee films!", "Iconic Australian actor Paul Hogan has signed a deal with Universal for 23 more Dundee films, including an ambitious crossover with The Fast and the Furious franchise. Click below, read more!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[0], "Snoop Dogg set to release his first Death Metal album!", "Snoop Dogg is set to change his name to Snoop Slayer and release his first Death Metal album after taking an adventurous trip to Germany. Click the link below to learn more!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[1], "Sexy sock sniffing singles in your area!", "Whether you’re a lonely sock loving man or woman, there’s someone in your neighbourhood waiting to sniff socks with you! Whether you like the smell, or just the taste, someone is waiting for you!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[1], "Over 70 over 70’s in your area!", "Someone special is out there for you, and it could be one of the over 70 women in your area who are over 70 and desperately want your phone number!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[1], "Sleep with a single tonight!", "Double beds are overrated! Sleep comfortably in a single bed tonight. There are many waiting for you and your friends in our warehouses across the globe!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[1], "Goth gamer girl looking to hook up!", "Are you a gamer? Are you longing for the perfect goth gamer girl? Get your Wiimote and Nunchuck out because there is one in your neighbourhood looking to play!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[1], "Dirty blondes in need of a bath!", "Just around the corner from you are dog owners with dirty Golden Retrievers who really need a wash! If you could give Dave and Janine a call, they would really appreciate it if you did that."));
            spamEmails.Add(new SpamEmail(SpamAuthors[2], "You have been exposed to a virus!", "Your data will soon be lost, but I can help you retrieve it! Make sure to respond with your credit card details so I can retrieve your data. Don’t forget those 3 pesky numbers on the back of the card!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[2], "I know someone who wants to date you!", "Hey there, I know someone who thinks you’re really hot! Trouble is, they need you to pay for their airplane ticket to you. Respond with your credit card details to get hooked up!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[2], "You have won a vacation to Quebec!", "Remember that contest you entered ages ago? Well, you have won! Respond with your credit card details for the $50 fee to accept your prize!"));
            spamEmails.Add(new SpamEmail(SpamAuthors[2], "Support starving children overseas!", "There are children dying all over the world! Support my charity and save hundreds of starving children immediately. Respond with your credit card details and the amount that you want to donate."));
            spamEmails.Add(new SpamEmail(SpamAuthors[2], "Buy sold out concert tickets before they sell out!", "Your favourite bands tour is sold out? Buy tickets here before it is too late! Respond with your credit card details and band name that you want tickets for! "));
        }

    }
}
