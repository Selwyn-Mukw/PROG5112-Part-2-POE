# CybersecurityChatbot
This is my POE bot which i created which will be able to interact and educate a user whom is interested in learning Cyber security
List of items that were implemented in Part 2
-CREATE A WPF
-Create all the required classes which will hold the logic of the bot
-MainWindow.xaml :This is where i desginded the GUI , creating blocks where the acsii art will be displayed, the name of the bot,the colour scheme alos of the bot , the font of the texts and create a section which will be for the chat history and create a send buttion which user will press when they have to send a response or answer.
-MainWindow.xaml.cs :This is where i added my welcome greeting which will play as the app/bot is launched, followed by the acsii art with a welcome message 
-KeywordResponder.xaml:This is where i created the response logic which will be stored in a list instead of an array .the user name will also be stored ansd saved then later on be recalled if the user uses the app for more than 3 attemopts with the suitable topics.STored a list of the answers for the keywords which will be randomly generated when a user chooses a word .I created a menu method that has a list of chooseable topics that the user can use ,Also created a user interest method which will display the users name after 3 rounds of choosing topics as an interest .
-Sentiment.cs This is where the bot will be able to pick up if the user is sad or worried and the bot will be able to give a few caring words to the user to try comfort them,also created a list of responsesd that the bot will use upon a certain response.
This bot runs based on the inputs of the user whereby the user will enter their name and describe how they are feeling.once user describes there feeling the bot will responnd based on what the user inputs .This bot will drop a list of all the topics which have a list of different meaning which will be randomly generated based on whta the user chooses.The user can choose differenty topics after 33 topic sthe bot will remmebr the users name and mention that they are really interested in cyber security.The user can end the program by pressing 0 which will kill the program.if the user logs back in the bot will remember the name as soon as the user inputs it.
MemoryStore.cs: this will store the memory and will be able to rewcall the users name should they type it after ending the session the bot will welcome the user back

here is my youtube link https://youtu.be/9t5xPtWagkY
<img width="1907" height="557" alt="Screenshot 2026-05-27 195130" src="https://github.com/user-attachments/assets/94d29bb3-7f57-437d-a74c-06b1456bbcda" />
<img width="1905" height="1006" alt="Bot remembers user name " src="https://github.com/user-attachments/assets/c535e346-7371-4047-a978-5c609ac7943b" />
<img width="1903" height="608" alt="image" src="https://github.com/user-attachments/assets/cd9fb871-4454-48ce-a6e0-a244679040cc" />
