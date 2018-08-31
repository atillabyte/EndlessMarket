# Endless Online Market Addon (beta)

## Video Preview
[![Video Preview](https://img.youtube.com/vi/o33KjChcQt0/0.jpg)](https://www.youtube.com/watch?v=o33KjChcQt0)

# Instructions

1. Restore nuget packages for each project in solution, and then build.
2. Create the following changes to EOSERV:
   In 'src/commands' add 'market.cpp' with the provided code: https://gist.github.com/fbde41c7111b26fb1b913450a2f4d9a5
   
   In 'src/handlers/Shop.cpp' add the provided code in the 'Shop_Open()' method, in the npcs foreach loop. https://gist.github.com/448207d940f6d426ab47d769a8c516bd
   
   In 'src/character.cpp' add the provided code in the 'Character::Login()' method, placed wherever should be fine. https://gist.github.com/78899379c9cae2fb89b25186fbb807d9

   In 'src/player.cpp' add the provided code in the 'Player::ChengePass()' method, directly under the DB query.
   `this->world->db.Commit();`
   
   In 'src/world.cpp' add the provided code in the '*World::CreateCharacter()' method, directly under the DB query.
   `this->db.Commit();`
   
3. When the newly modified EOServ is built, place the MarketAPI.exe from 'EndlessMarket.Server' in the output directory.
   (i.e. wherever the eoserv.exe binary resides)
   
4. Create the following INI file in the EOServ output directory config folder, named 'market.ini' and add the following text inside the newly created 'market.ini' file,  the username and password

4. Create the following INI file in the EOServ output directory config folder, appropriately named 'market.ini' and replace the login details with an existing HGM admin account, with the admin character being in the first character slot.
   ```ini
    ### MARKET OPTIONS ###

    ## MarketAdminAccount (string)
    # The account the API bot should connect with, colon delimited.
    MarketAdminAccount = username:password
   ```
5. Using a pub file editor, create an NPC with the ID '410' with the 'Shop' NPC attribute. You can name it however you like.

6. In the Endless Online client folder, place the 'endless_merged.exe' from the 'EndlessMarket' x86 build output directory.
7. Launch the 'MarketAPI.exe' executable and when the bot is connected, launch 'endless_merged.exe' and connect to the game.
8. Spawn the NPC with the ID '410' and click on the NPC. If all is well, the market dialog should appear, and should allow you to sell and purchase items.

###### Note: If you do not see incoming and outgoing packets being logged after starting 'endless_merged.exe' then something is wrong, and you should try restarting the client. If that doesn't work, or if there are any other problems, open an issue. :)
