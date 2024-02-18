using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Snap_It_Version2_Windows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int SCREEN_WIDTH = 430 * 2 / 3; 
        public const int SCREEN_HEIGHT = 932 * 2 / 3;

        public const int LOGO_STATE = 0;
        public const int PIN_STATE = 1;
        public const int HOME_STATE = 2;
        public const int ANALYTICS_STATE = 3;
        public const int CAMERA_STATE = 4;
        public const int ANALYZED_STATE = 5;
        public const int SETTINGS = 6;
        public const int TRACKING_STATE = 7;
        public const int JOURNAL = 8;
        public const int COMMUNITY = 9;

        public const int MENU_BTN_SPACING = 30;

        private string password = "1234";

        private bool droppedDown = false;
        private int numNumsEntered = 0;
        private string curPassword = "";

        private Texture2D[] numBtns = new Texture2D[10];
        private Texture2D arrowUp;
        private Texture2D arrowDown;
        private Texture2D arrowLeft;
        private Texture2D arrowRight;
        private Texture2D menuBtn;
        private Texture2D[] optionBtns = new Texture2D[5];
        private Texture2D logo;
        private Texture2D pixel;

        private Texture2D motiv1;
        private Texture2D bar;
        private Texture2D dropdown;

        private Texture2D camIcon;

        private Texture2D profilePic;
        private Texture2D profileMask;

        private Rectangle[] numBtnRecs = new Rectangle[10];
        private Rectangle arrowUpRec;
        private Rectangle arrowDownRec;
        private Rectangle arrowLeftRec;
        private Rectangle arrowRightRec;
        private Rectangle menuBtnRec;
        private Rectangle[] optionBtnRecs = new Rectangle[5];
        private Rectangle logoRec;
        private Rectangle pinPadRec;

        private Rectangle motiv1Rec;
        private Rectangle barRec;
        private Rectangle dropdownRec;

        private Rectangle camIconRec;

        private int gameState = LOGO_STATE;

        private SpriteFont font;

        private SoundEffect clickSnd;

        private string pinMsg = "Enter your passcode";
        private Vector2 pinMsgLoc;
        private Rectangle [] pinLocs = new Rectangle[4];
        
        private Rectangle profilePicRec;
        private Rectangle profileMaskRec;

        private MouseState prevMouse;
        private MouseState mouse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Set the game screen size
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            //Set the mouse as visible
            IsMouseVisible = true;

            //Apply the changes to the game graphics
            graphics.ApplyChanges();

            base.Initialize();
    }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            numBtns[0] = Content.Load<Texture2D>("Imgs/Btns/Btn0");
            numBtns[1] = Content.Load<Texture2D>("Imgs/Btns/Btn1");
            numBtns[2] = Content.Load<Texture2D>("Imgs/Btns/Btn2");
            numBtns[3] = Content.Load<Texture2D>("Imgs/Btns/Btn3");
            numBtns[4] = Content.Load<Texture2D>("Imgs/Btns/Btn4");
            numBtns[5] = Content.Load<Texture2D>("Imgs/Btns/Btn5");
            numBtns[6] = Content.Load<Texture2D>("Imgs/Btns/Btn6");
            numBtns[7] = Content.Load<Texture2D>("Imgs/Btns/Btn7");
            numBtns[8] = Content.Load<Texture2D>("Imgs/Btns/Btn8");
            numBtns[9] = Content.Load<Texture2D>("Imgs/Btns/Btn9");

            arrowDown = Content.Load<Texture2D>("Imgs/Btns/ArrowDown");
            arrowUp = Content.Load<Texture2D>("Imgs/Btns/ArrowUp");
            arrowLeft = Content.Load<Texture2D>("Imgs/Btns/ArrowBack");
            arrowRight = Content.Load<Texture2D>("Imgs/Btns/ArrowGo");

            optionBtns[0] = Content.Load<Texture2D>("Imgs/Btns/OptionBtn1");
            optionBtns[1] = Content.Load<Texture2D>("Imgs/Btns/OptionBtn2");
            optionBtns[2] = Content.Load<Texture2D>("Imgs/Btns/OptionBtn3");
            optionBtns[3] = Content.Load<Texture2D>("Imgs/Btns/OptionBtn4");
            optionBtns[4] = Content.Load<Texture2D>("Imgs/Btns/OptionBtn5");

            menuBtn = Content.Load<Texture2D>("Imgs/Btns/menuBtn");
            logo = Content.Load<Texture2D>("Imgs/Btns/SnapIt200Pxl");
            camIcon = Content.Load<Texture2D>("Imgs/Btns/camIcon");

            pixel = Content.Load<Texture2D>("Imgs/Btns/PixelImg");

            motiv1 = Content.Load<Texture2D>("Imgs/BgImgs/DailyMotivation1");
            bar = Content.Load<Texture2D>("Imgs/BgImgs/SnapItBar");
            dropdown = Content.Load<Texture2D>("Imgs/BgImgs/SnapItDropdown");

            profilePic = Content.Load<Texture2D>("Imgs/Btns/profilePic");
            profileMask = Content.Load<Texture2D>("Imgs/Btns/profilePicMask");

            font = Content.Load<SpriteFont>("Fonts/MenuFont");

            clickSnd = Content.Load<SoundEffect>("sounds/BtnSelectSnd");

            numBtnRecs[1] = new Rectangle(SCREEN_WIDTH / 3 - numBtns[0].Width, SCREEN_HEIGHT * 2 / 3, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[2] = new Rectangle(2 + numBtnRecs[1].Right, SCREEN_HEIGHT * 2 / 3, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[3] = new Rectangle(2 + numBtnRecs[2].Right, SCREEN_HEIGHT * 2 / 3, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[4] = new Rectangle(numBtnRecs[1].X, numBtnRecs[1].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[5] = new Rectangle(numBtnRecs[2].X, numBtnRecs[1].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[6] = new Rectangle(numBtnRecs[3].X, numBtnRecs[1].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[7] = new Rectangle(numBtnRecs[4].X, numBtnRecs[4].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[8] = new Rectangle(numBtnRecs[5].X, numBtnRecs[4].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[9] = new Rectangle(numBtnRecs[6].X, numBtnRecs[4].Bottom + 2, numBtns[0].Width, numBtns[0].Height);
            numBtnRecs[0] = new Rectangle(numBtnRecs[2].X, numBtnRecs[7].Bottom + 2, numBtns[0].Width, numBtns[0].Height);

            pinPadRec = new Rectangle(0, numBtnRecs[1].Y - 5, SCREEN_WIDTH, SCREEN_HEIGHT / 3 + 10);

            pinMsgLoc = new Vector2(SCREEN_WIDTH / 2 - font.MeasureString(pinMsg).X / 2, SCREEN_HEIGHT / 3);
            pinLocs[1] = new Rectangle(SCREEN_WIDTH / 2 - 10, (int)pinMsgLoc.Y + 50, 5, 5);
            pinLocs[2] = new Rectangle(SCREEN_WIDTH / 2 + 10, (int)pinMsgLoc.Y + 50, 5, 5);
            pinLocs[0] = new Rectangle(pinLocs[1].X - 20, (int)pinMsgLoc.Y + 50, 5, 5);
            pinLocs[3] = new Rectangle(pinLocs[2].X + 20, (int)pinMsgLoc.Y + 50, 5, 5);

            motiv1Rec = new Rectangle(0, 0, SCREEN_WIDTH, motiv1.Height);
            barRec = new Rectangle(0, 0, SCREEN_WIDTH, bar.Height);
            dropdownRec = new Rectangle(0, 0, SCREEN_WIDTH, dropdown.Height);
            //arrowDownRec = new Rectangle(SCREEN_WIDTH / 2 - arrowDown.Width / 2, barRec.Bottom - arrowDown.Height - 5, arrowDown.Width, arrowDown.Height);
            arrowUpRec = new Rectangle(SCREEN_WIDTH / 2 - arrowDown.Width / 2, dropdownRec.Bottom - arrowDown.Height - 5, arrowDown.Width, arrowDown.Height);
            menuBtnRec = new Rectangle(10, barRec.Bottom - menuBtn.Height - 10, menuBtn.Width, menuBtn.Height);

            //arrowDownRec = Content.Load<Texture2D>("Imgs/Btns/ArrowDown");
            //arrowUpRec = Content.Load<Texture2D>("Imgs/Btns/ArrowDown");
            //arrowLeftRec = Content.Load<Texture2D>("Imgs/Btns/ArrowBack");
            //arrowRightRec = Content.Load<Texture2D>("Imgs/Btns/ArrowGo");

            optionBtnRecs[0] = new Rectangle(SCREEN_WIDTH / 2 - optionBtns[0].Width / 2, barRec.Bottom, optionBtns[0].Width, optionBtns[0].Height);
            optionBtnRecs[1] = new Rectangle(SCREEN_WIDTH / 2 - optionBtns[0].Width / 2, optionBtnRecs[0].Bottom + MENU_BTN_SPACING, optionBtns[0].Width, optionBtns[0].Height);
            optionBtnRecs[2] = new Rectangle(SCREEN_WIDTH / 2 - optionBtns[0].Width / 2, optionBtnRecs[1].Bottom + MENU_BTN_SPACING, optionBtns[0].Width, optionBtns[0].Height);
            optionBtnRecs[3] = new Rectangle(SCREEN_WIDTH / 2 - optionBtns[0].Width / 2, optionBtnRecs[2].Bottom + MENU_BTN_SPACING, optionBtns[0].Width, optionBtns[0].Height);
            optionBtnRecs[4] = new Rectangle(SCREEN_WIDTH / 2 - optionBtns[0].Width / 2, optionBtnRecs[3].Bottom + MENU_BTN_SPACING, optionBtns[0].Width, optionBtns[0].Height);

            camIconRec = new Rectangle(SCREEN_WIDTH / 2 - camIcon.Width / 2, SCREEN_HEIGHT - 80, camIcon.Width, camIcon.Height);

            logoRec = new Rectangle(SCREEN_WIDTH / 2 - logo.Width / 2, SCREEN_HEIGHT / 2 - logo.Height / 2, logo.Width, logo.Height);

            //profilePicRec = new Rectangle(barRec.Bottom + profileMask.Width, profileMask.Height);
            //motiv1Rec = Content.Load<Texture2D>("Imgs/BgImgs/DailyMotivation1");
            //barRec = Content.Load<Texture2D>("Imgs/BgImgs/SnapItBar");
            //dropdownRec = Content.Load<Texture2D>("Imgs/BgImgs/SnapItDropdown");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevMouse = mouse;
            mouse = Mouse.GetState();

            // TODO: Add your update logic here
            switch (gameState)
            {
                case LOGO_STATE:
                    if (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton != ButtonState.Pressed)
                    {
                        gameState = PIN_STATE;
                    }
                    break;
                case PIN_STATE:
                    if (numNumsEntered < 4)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (BtnPressed(numBtnRecs[i]))
                            {
                                numNumsEntered++;
                                curPassword += "" + i;
                            }
                        }
                    }

                    if (curPassword.Equals(password))
                    {
                        gameState = HOME_STATE;
                    }
                    else if (numNumsEntered >= 4)
                    {
                        curPassword = "";
                        numNumsEntered = 0;
                    }
                    break;
                case HOME_STATE:
                    if (droppedDown)
                    {
                        if (BtnPressed(arrowUpRec))
                        {
                            droppedDown = false;
                        }
                        else if (BtnPressed(optionBtnRecs[0]))
                        {
                            gameState = ANALYTICS_STATE;
                        }
                        else if (BtnPressed(optionBtnRecs[1]))
                        {
                            gameState = TRACKING_STATE;
                        }
                        else if (BtnPressed(optionBtnRecs[2]))
                        {
                            gameState = JOURNAL;
                        }
                        else if (BtnPressed(optionBtnRecs[3]))
                        {
                            gameState = COMMUNITY;
                        }
                        else if (BtnPressed(optionBtnRecs[4]))
                        {
                            gameState = SETTINGS;
                        }
                    }
                    else
                    {
                        if (BtnPressed(menuBtnRec))
                        {
                            droppedDown = true;
                        }
                    }

                    if (BtnPressed(camIconRec))
                    {
                        gameState = CAMERA_STATE;
                    }
                    break;
                case CAMERA_STATE:
                    break;
                case ANALYTICS_STATE:
                    break;
                case TRACKING_STATE:
                    break;
                case JOURNAL:
                    break;
                case COMMUNITY:
                    break;
                case SETTINGS:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (gameState)
            {
                case LOGO_STATE:
                    GraphicsDevice.Clear(Color.White);
                    spriteBatch.Draw(logo, logoRec, Color.White);
                    break;
                case PIN_STATE:
                    GraphicsDevice.Clear(Color.White);
                    spriteBatch.DrawString(font, pinMsg, pinMsgLoc, Color.Black);
                    
                    for (int i = 0; i < numNumsEntered; i++)
                    {
                        spriteBatch.Draw(pixel, pinLocs[i], Color.Black);
                    }

                    spriteBatch.Draw(pixel, pinPadRec, Color.Gray);

                    for (int i = 0; i < 10; i++)
                    {
                        spriteBatch.Draw(numBtns[i], numBtnRecs[i], Color.White);
                    }
                    break;
                case HOME_STATE:
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                    
                    if (droppedDown)
                    {
                        spriteBatch.Draw(motiv1, motiv1Rec, Color.White * 0.5f);
                        spriteBatch.Draw(dropdown, dropdownRec, Color.White);

                        for (int i = 0; i < 5; i++)
                        {
                            spriteBatch.Draw(optionBtns[i], optionBtnRecs[i], Color.White);
                        }

                        spriteBatch.Draw(arrowUp, arrowUpRec, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(motiv1, motiv1Rec, Color.White);
                        spriteBatch.Draw(bar, barRec, Color.White);
                        spriteBatch.Draw(menuBtn, menuBtnRec, Color.White);
                    }

                    spriteBatch.Draw(camIcon, camIconRec, Color.White);

                    break;
                case CAMERA_STATE:
                    break;
                case ANALYTICS_STATE:
                    break;
                case TRACKING_STATE:
                    break;
                case JOURNAL:
                    break;
                case COMMUNITY:
                    break;
                case SETTINGS:
                    break;
                default:
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private bool BtnPressed(Rectangle btnRec)
        {
            if (mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton != ButtonState.Pressed && btnRec.Contains(mouse.Position))
            {
                clickSnd.CreateInstance().Play();
                return true;
            }

            return false;
        }
    }
}


