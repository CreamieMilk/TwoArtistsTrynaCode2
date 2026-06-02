using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media; // Added for audio

namespace CookingSimulator
{
    public enum GameState
    {
        TitleScreen,
        MamaIntro,
        LevelSelect,
        CookingPizza,
        CookingCorndog,
        CookingPie,
        RecipeResults,
        FinalGrades
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private UIManager uiManager;
        private Pizza pizzaLevel;
        private Corndog corndogLevel;
        private Pie pieLevel;
        private GameState currentState = GameState.TitleScreen;
        
        private bool pizzaDone = false;
        private bool corndogDone = false;
        private bool pieDone = false;

        private int pizzaScore = 0;
        private int corndogScore = 0;
        private int pieScore = 0;
        
        private Texture2D titleVector;
        private Texture2D textBoxBackground; 
        private Texture2D mamaexcited, mamaHappy, mamaupset, mamaregular, mamatalking, mamaexplain;
        private Texture2D btnPizza, btnCorndog, btnPie;
        private Texture2D popupPerfect, popupGood, popupBad;
        private Texture2D currentPopup, endScreenMamaPortrait;
        private Song backgroundMusic; // Added music field

        private SpriteFont mainFont;
        private int dialogueLine = 0; 
        private MouseState previousMouse;
        private KeyboardState previousKey;
        private float bounceOffset;
        
        private List<string> mamaScript = new List<string>
        {
            "Sweetie!",
            "I'll need your help cooking today.",
            "We'll be baking pizza, corndogs and some pie today!",
            "So... which one would you want to help mama with first? :D"
        };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 650;
        }

        protected override void Initialize()
        {
            pizzaLevel = new Pizza();
            corndogLevel = new Corndog();
            pieLevel = new Pie();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            uiManager = new UIManager(GraphicsDevice, spriteBatch); 
            mainFont = Content.Load<SpriteFont>("MainFont");
            uiManager.Font = mainFont;

            textBoxBackground = Content.Load<Texture2D>("TextBox");
            mamaHappy = Content.Load<Texture2D>("MamaHappy");
            mamaexcited = Content.Load<Texture2D>("MamaExcited");
            mamaupset = Content.Load<Texture2D>("MamaUpset");
            mamaregular = Content.Load<Texture2D>("MamaRegular");
            mamatalking = Content.Load<Texture2D>("MamaTalking");
            mamaexplain = Content.Load<Texture2D>("MamaExplain");
            titleVector = Content.Load<Texture2D>("TitleLogo");
            btnPizza = Content.Load<Texture2D>("button_pizza_idle");
            btnCorndog = Content.Load<Texture2D>("button_corndog_idle");
            btnPie = Content.Load<Texture2D>("button_pie_idle");
            
            popupPerfect = Content.Load<Texture2D>("popupAmazing"); 
            popupGood = Content.Load<Texture2D>("popupGood"); 
            popupBad = Content.Load<Texture2D>("popupMiss"); 
            
            // Load and start music
            backgroundMusic = Content.Load<Song>("bakingfrenzymusic");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);

            pizzaLevel.LoadContent(Content);
            corndogLevel.LoadContent(Content);
            pieLevel.LoadContent(Content);
            pizzaLevel.LoadBaseContent(Content);
            corndogLevel.LoadBaseContent(Content);
            pieLevel.LoadBaseContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouse = Mouse.GetState();
            KeyboardState currentKey = Keyboard.GetState();
            bool isClicked = currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released;
            bounceOffset = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 5f) * 10f;

            switch (currentState)
            {
                case GameState.TitleScreen:
                    if (isClicked) { currentState = GameState.MamaIntro; dialogueLine = 0; }
                    break;
                case GameState.MamaIntro:
                    if (isClicked) { dialogueLine++; if (dialogueLine > 3) currentState = GameState.LevelSelect; }
                    break;
                case GameState.LevelSelect:
                    Rectangle pizzaHitbox = new Rectangle(100, 350, 200, 200);
                    Rectangle pieHitbox = new Rectangle(350, 350, 200, 200);
                    Rectangle corndogHitbox = new Rectangle(600, 350, 200, 200);
                    if (isClicked)
                    {
                        if (pizzaHitbox.Contains(currentMouse.Position) && !pizzaDone) currentState = GameState.CookingPizza;
                        else if (pieHitbox.Contains(currentMouse.Position) && !pieDone) currentState = GameState.CookingPie;
                        else if (corndogHitbox.Contains(currentMouse.Position) && !corndogDone) currentState = GameState.CookingCorndog;
                    }
                    else if (pizzaDone && corndogDone && pieDone) 
                    {
                        float percentage = (pizzaScore + corndogScore + pieScore) / 300f;
                        if (percentage >= 0.90f) { currentPopup = popupPerfect; endScreenMamaPortrait = mamaexcited; }
                        else if (percentage >= 0.50f) { currentPopup = popupGood; endScreenMamaPortrait = mamaHappy; }
                        else { currentPopup = popupBad; endScreenMamaPortrait = mamaupset; }
                        currentState = GameState.FinalGrades;
                    }
                    break;
                case GameState.CookingPizza:
                    pizzaLevel.Update(gameTime); 
                    if (pizzaLevel.IsLevelComplete) { pizzaDone = true; pizzaScore = pizzaLevel.FinalLevelScore; currentState = GameState.RecipeResults; }
                    break;
                case GameState.CookingCorndog:
                    corndogLevel.Update(gameTime); 
                    if (corndogLevel.IsLevelComplete) { corndogDone = true; corndogScore = corndogLevel.FinalLevelScore; currentState = GameState.RecipeResults; }
                    break;
                case GameState.CookingPie:
                    pieLevel.Update(gameTime); 
                    if (pieLevel.IsLevelComplete) { pieDone = true; pieScore = pieLevel.FinalLevelScore; currentState = GameState.RecipeResults; }
                    break;
                case GameState.RecipeResults:
                    if (isClicked) currentState = GameState.LevelSelect; 
                    break;
                case GameState.FinalGrades:
                    if (isClicked) Exit();
                    break;
            }
            previousMouse = currentMouse;
            previousKey = currentKey;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            spriteBatch.Begin();
            Texture2D bg = Content.Load<Texture2D>("MainBackground");
            spriteBatch.Draw(bg, new Rectangle(0, 0, 900, 650), Color.White);

            switch (currentState)
            {
                case GameState.TitleScreen:
                    if (titleVector != null) spriteBatch.Draw(titleVector, new Vector2(-50, -10 + bounceOffset), null, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
                    break;
                case GameState.MamaIntro:
                    Texture2D p = (dialogueLine == 1) ? mamaexplain : (dialogueLine == 2 ? mamaexcited : mamatalking);
                    uiManager.DrawDialogue(textBoxBackground, p, "Mama", mamaScript[dialogueLine]);
                    break;
                case GameState.LevelSelect:
                    uiManager.DrawDialogue(textBoxBackground, mamaregular, "", "");
                    if (!pizzaDone) uiManager.DrawButton(btnPizza, new Rectangle(120, 485, 130, 130));
                    if (!pieDone) uiManager.DrawButton(btnPie, new Rectangle(375, 485, 130, 130));
                    if (!corndogDone) uiManager.DrawButton(btnCorndog, new Rectangle(630, 485, 130, 130));
                    break;
                case GameState.CookingPizza: pizzaLevel.Draw(spriteBatch); break;
                case GameState.CookingCorndog: corndogLevel.Draw(spriteBatch); break;
                case GameState.CookingPie: pieLevel.Draw(spriteBatch); break;
                case GameState.RecipeResults: uiManager.DrawDialogue(textBoxBackground, mamaHappy, "Mama", "Great job! Click to go back."); break;
                case GameState.FinalGrades:
                    uiManager.DrawDialogue(textBoxBackground, endScreenMamaPortrait, "", "");
                    if (currentPopup != null) spriteBatch.Draw(currentPopup, new Vector2(50, 150), null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

namespace CookingSimulator
{
    public class UIManager
    {
        private Texture2D pixel;
        private SpriteBatch sb;
        private SpriteFont font;

        public SpriteFont Font { set { font = value; } }

        public UIManager(GraphicsDevice gd, SpriteBatch sb)
        {
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData(new[] { Color.White });
            this.sb = sb;
        }

        public void DrawButton(Texture2D texture, Rectangle rect)
        {
            sb.Draw(texture, rect, Color.White);
        }

        public bool IsButtonClicked(Rectangle rect, MouseState mouse, MouseState prevMouse)
        {
            return rect.Contains(mouse.Position) && 
                   mouse.LeftButton == ButtonState.Pressed && 
                   prevMouse.LeftButton == ButtonState.Released;
        }

        public void DrawDialogue(Texture2D boxTexture, Texture2D portrait, string name, string text)
        {
            if (portrait != null)
                sb.Draw(portrait, new Rectangle(250, 80, 400, 400), Color.White);

            Rectangle boxRect = new Rectangle(0, 200, 900, 550);
            if (boxTexture != null)
                sb.Draw(boxTexture, boxRect, Color.White);

            if (font != null)
            {
                sb.DrawString(font, name, new Vector2(boxRect.X + 80, boxRect.Y + 250), Color.Black);
                sb.DrawString(font, text, new Vector2(boxRect.X + 80, boxRect.Y + 300), Color.Black, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            }
            else 
            {
                DrawText(name, boxRect.X + 80, boxRect.Y + 250, Color.Black);
                DrawText(text, boxRect.X + 80, boxRect.Y + 300, Color.Black);
            }
        }

        public void DrawRect(float x, float y, float w, float h, Color c)
        {
            sb.Draw(pixel, new Rectangle((int)x, (int)y, (int)w, (int)h), c);
        }
        
        public void DrawText(string t, float x, float y, Color c, bool center = false)
        {
            if (center) x -= t.Length * 4;
            for (int i = 0; i < t.Length; i++)
                sb.Draw(pixel, new Rectangle((int)x + i * 8, (int)y, 6, 12), c);
        }
    }
}