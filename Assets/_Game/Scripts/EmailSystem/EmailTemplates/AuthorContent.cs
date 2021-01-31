using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmailSystem.Content {
	public class AuthorContent : MonoBehaviour {
        [SerializeField] private Sprite[] authorSprites = new Sprite[6];

        private List<Author> officeAuthors = new List<Author>();

        public void Populate() {
            officeAuthors.Add(new Author(authorSprites[0], "Bruce King ", "theking@lagless.com"));
            officeAuthors.Add(new Author(authorSprites[1], "Rajesh Kumar", "rajesh@lagless.com"));
            officeAuthors.Add(new Author(authorSprites[2], "Barry Fonda", "barry@lagless.com"));
            officeAuthors.Add(new Author(authorSprites[3], "Tiffany Day", "Tiffany Day"));
            officeAuthors.Add(new Author(authorSprites[4], "Tamika Williams", "Tamika Williams"));
            officeAuthors.Add(new Author(authorSprites[5], "Byron Smith", "Byron Smith"));
        }

        public Author GetRandomAuthor(Author notAuthor) {
            int author = Random.Range(0, officeAuthors.Count);
            int notAuthorIndex = officeAuthors.IndexOf(notAuthor);

            if (author == notAuthorIndex) {
                if (author > 0 && author == notAuthorIndex) return officeAuthors[author - 1];
                else return officeAuthors[author + 1];
            }

            return officeAuthors[author];
		}

        public Author GetRandomAuthor() {
            int author = Random.Range(0, officeAuthors.Count);
            return officeAuthors[author];
        }
    }
}
