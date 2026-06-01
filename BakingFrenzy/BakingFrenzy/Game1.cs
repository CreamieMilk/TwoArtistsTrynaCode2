using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private UIManager _uiManager;
        private Pizza _pizzaLevel;
        private Corndog _corndogLevel;
        private Pie _pieLevel;
        private GameState _currentState = GameState.TitleScreen;
        
        private bool _pizzaDone = false;
        private bool _corndogDone = false;
        private bool _pieDone = false;

        private int _pizzaScore = 0;
        private int _corndogScore = 0;
        private int _pieScore = 0;
        
        private Texture2D _titleVector;
        private Texture2D textBoxBackground; 
        private Texture2D mamaexcited, mamaHappy, mamaupset, mamaregular, mamatalking, mamaexplain;
        
        // The custom button variables
        private Texture2D btnPizza, btnCorndog, btnPie;

        private SpriteFont _mainFont;
        
        private int _dialogueLine = 0; 
        private MouseState _previousMouse;
        private KeyboardState _previousKey;

        private float _bounceOffset;
        
        private string[] _mamaScript = new string[]
        {
            "Sweetie!",
            "I'll need your help cooking today.",
            "We'll be baking pizza, corndogs and some pie today!",
            "So... which one would you want to help mama with first? :D"
        };

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 650;
        }

        protected override void Initialize()
        {
            _pizzaLevel = new Pizza();
            _corndogLevel = new Corndog();
            _pieLevel = new Pie();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _uiManager = new UIManager(GraphicsDevice, _spriteBatch); 
            
            _mainFont = Content.Load<SpriteFont>("MainFont");
            _uiManager.Font = _mainFont;

            textBoxBackground = Content.Load<Texture2D>("TextBox");
            mamaHappy = Content.Load<Texture2D>("MamaHappy");
            mamaexcited = Content.Load<Texture2D>("MamaExcited");
            mamaupset = Content.Load<Texture2D>("MamaUpset");
            mamaregular = Content.Load<Texture2D>("MamaRegular");
            mamatalking = Content.Load<Texture2D>("MamaTalking");
            mamaexplain = Content.Load<Texture2D>("MamaExplain");
            
            _titleVector = Content.Load<Texture2D>("TitleLogo");
            
            // Loading your specific button assets
            btnPizza = Content.Load<Texture2D>("button_pizza_idle");
            btnCorndog = Content.Load<Texture2D>("button_corndog_idle");
            btnPie = Content.Load<Texture2D>("button_pie_idle");

            _pizzaLevel.LoadContent(Content);
            _corndogLevel.LoadContent(Content);
            _pieLevel.LoadContent(Content);
            
            _pizzaLevel.LoadBaseContent(Content);
            _corndogLevel.LoadBaseContent(Content);
            _pieLevel.LoadBaseContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouse = Mouse.GetState();
            KeyboardState currentKey = Keyboard.GetState();

            bool isClicked = currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released;

            _bounceOffset = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 5f) * 10f;

            switch (_currentState)
            {
                case GameState.TitleScreen:
                    if (isClicked) 
                    {
                        _currentState = GameState.MamaIntro;
                        _dialogueLine = 0; 
                    }
                    break;

                case GameState.MamaIntro:
                    if (isClicked)
                    {
                        _dialogueLine++; 
                        
                        if (_dialogueLine > 3) 
                        {
                            _currentState = GameState.LevelSelect;
                        }
                    }
                    break;

                case GameState.LevelSelect:
                   
                    Rectangle pizzaHitbox = new Rectangle(100, 350, 200, 200);
                    Rectangle pieHitbox = new Rectangle(350, 350, 200, 200);
                    Rectangle corndogHitbox = new Rectangle(600, 350, 200, 200);

                    if (isClicked)
                    {
                        if (pizzaHitbox.Contains(currentMouse.Position) && !_pizzaDone) 
                            _currentState = GameState.CookingPizza;
                        else if (pieHitbox.Contains(currentMouse.Position) && !_pieDone) 
                            _currentState = GameState.CookingPie;
                        else if (corndogHitbox.Contains(currentMouse.Position) && !_corndogDone) 
                            _currentState = GameState.CookingCorndog;
                    }
                    else if (_pizzaDone && _corndogDone && _pieDone)
                    {
                        _currentState = GameState.FinalGrades;
                    }
                    break;

                case GameState.CookingPizza:
                    _pizzaLevel.Update(gameTime); 

                    if (_pizzaLevel.IsLevelComplete) 
                    {
                        _pizzaDone = true;
                        _pizzaScore = _pizzaLevel.FinalLevelScore;
                        _currentState = GameState.RecipeResults;
                    }
                    break;

                case GameState.CookingCorndog:
                    _corndogLevel.Update(gameTime); 

                    if (_corndogLevel.IsLevelComplete) 
                    {
                        _corndogDone = true;
                        _corndogScore = _corndogLevel.FinalLevelScore;
                        _currentState = GameState.RecipeResults;
                    }
                    break;

                case GameState.CookingPie:
                    _pieLevel.Update(gameTime); 

                    if (_pieLevel.IsLevelComplete) 
                    {
                        _pieDone = true;
                        _pieScore = _pieLevel.FinalLevelScore;
                        _currentState = GameState.RecipeResults;
                    }
                    break;

                case GameState.RecipeResults:
                    if (isClicked)
                    {
                        _currentState = GameState.LevelSelect; 
                    }
                    break;

                case GameState.FinalGrades:
                    if (isClicked)
                    {
                    }
                    break;
            }

            _previousMouse = currentMouse;
            _previousKey = currentKey;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            _spriteBatch.Begin();

            // Background
            Texture2D bg = Content.Load<Texture2D>("MainBackground");
            _spriteBatch.Draw(bg, new Rectangle(0, 0, 900, 650), Color.White);

            switch (_currentState)
            {
              case GameState.TitleScreen:
                if (_titleVector != null)
                    {
                    // Decreased X and Y to 10 to move it further into the top-left corner
                    Vector2 logoPosition = new Vector2(-50, -10 + _bounceOffset);
        
                    // Keep the scale at 0.4f (or whatever size you prefer)
                    _spriteBatch.Draw(_titleVector, logoPosition, null, Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
                    }
                break;

                case GameState.MamaIntro:
                    Texture2D currentPortrait = mamatalking; 
                    if (_dialogueLine == 1) currentPortrait = mamaexplain;
                    else if (_dialogueLine == 2) currentPortrait = mamaexcited;

                    _uiManager.DrawDialogue(textBoxBackground, currentPortrait, "Mama", _mamaScript[_dialogueLine]);
                    break;

                case GameState.LevelSelect:
                    // Mama and the box stay, but no text is drawn because we pass empty strings
                    _uiManager.DrawDialogue(textBoxBackground, mamaregular, "", "");
                    
                    // The three clickable buttons
                    if (!_pizzaDone) _uiManager.DrawButton(btnPizza, new Rectangle(120, 485, 130, 130));
                    if (!_pieDone) _uiManager.DrawButton(btnPie, new Rectangle(375, 485, 130, 130));
                    if (!_corndogDone) _uiManager.DrawButton(btnCorndog, new Rectangle(630, 485, 130, 130));
                    break;

                case GameState.CookingPizza:
                    _pizzaLevel.Draw(_spriteBatch);
                    break;

                case GameState.CookingCorndog:
                    _corndogLevel.Draw(_spriteBatch);
                    break;

                case GameState.CookingPie:
                    _pieLevel.Draw(_spriteBatch);
                    break;

                case GameState.RecipeResults:
                    _uiManager.DrawDialogue(textBoxBackground, mamaHappy, "Mama", "Great job! Click to go back to the menu.");
                    break;

                case GameState.FinalGrades:
                    _uiManager.DrawDialogue(textBoxBackground, mamaexcited, "Mama", "You finished all the recipes!");
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

namespace CookingSimulator
{
    public class UIManager
    {
        private Texture2D _pixel;
        private SpriteBatch _sb;
        private SpriteFont _font;

        public SpriteFont Font { set { _font = value; } }

        public UIManager(GraphicsDevice gd, SpriteBatch sb)
        {
            _pixel = new Texture2D(gd, 1, 1);
            _pixel.SetData(new[] { Color.White });
            _sb = sb;
        }

        // New helper to draw the buttons easily
        public void DrawButton(Texture2D texture, Rectangle rect)
        {
            _sb.Draw(texture, rect, Color.White);
        }

        // New helper to check if a button was clicked
        public bool IsButtonClicked(Rectangle rect, MouseState mouse, MouseState prevMouse)
        {
            return rect.Contains(mouse.Position) && 
                   mouse.LeftButton == ButtonState.Pressed && 
                   prevMouse.LeftButton == ButtonState.Released;
        }

        public void DrawDialogue(Texture2D boxTexture, Texture2D portrait, string name, string text)
        {
            if (portrait != null)
            {
                _sb.Draw(portrait, new Rectangle(250, 80, 400, 400), Color.White);
            }

            Rectangle boxRect = new Rectangle(0, 200, 900, 550);
            if (boxTexture != null)
            {
                _sb.Draw(boxTexture, boxRect, Color.White);
            }

            if (_font != null)
            {
                _sb.DrawString(_font, name, new Vector2(boxRect.X + 80, boxRect.Y + 250), Color.Black);
                _sb.DrawString(_font, text, new Vector2(boxRect.X + 80, boxRect.Y + 300), Color.Black, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            }
            else 
            {
                DrawText(name, boxRect.X + 80, boxRect.Y + 250, Color.Black);
                DrawText(text, boxRect.X + 80, boxRect.Y + 300, Color.Black);
            }
        }

        public void DrawRect(float x, float y, float w, float h, Color c)
        {
            _sb.Draw(_pixel, new Rectangle((int)x, (int)y, (int)w, (int)h), c);
        }
        
        public void DrawText(string t, float x, float y, Color c, bool center = false)
        {
            if (center) x -= t.Length * 4;
            for (int i = 0; i < t.Length; i++)
                _sb.Draw(_pixel, new Rectangle((int)x + i * 8, (int)y, 6, 12), c);
        }
    }
}