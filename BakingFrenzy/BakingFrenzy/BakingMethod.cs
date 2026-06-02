using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CookingSimulator
{
    public abstract class BakingMethods
    {
        public string Name { get; protected set; }
        public bool IsLevelComplete { get; protected set; } = false;
        public int FinalLevelScore { get; protected set; } = 0; 

        protected int currentStep = 0;
        protected float currentSwipeDistance = 0f;
        protected float cookingProgress = 0f;
        protected bool progressIncreasing = true;

        protected Vector2 centerStage, hintLocation, corner1, corner2, corner3, corner4;
        
        protected Texture2D bgTable, bgStove, bgOven, emptyBowl, pot, pan;
        protected Texture2D water, sugar, salt, egg, milk, flour;
        protected Texture2D hintPressE, hintSwipeHoriz, hintSwipeVert, hintClick, hintSpacebar;
        protected Texture2D uiBarBackground, uiMeterNeedle, popupAmazing, popupGood, popupMiss;

        public BakingMethods()
        {
            centerStage = new Vector2(300, 380);
            hintLocation = new Vector2(550, 270); 
            corner1 = new Vector2(100, 250);
            corner2 = new Vector2(100, 400);
            corner3 = new Vector2(500, 250);
            corner4 = new Vector2(500, 400);
        }

        public virtual void LoadBaseContent(ContentManager Content)
        {
            bgTable = Content.Load<Texture2D>("bgTable");
            bgStove = Content.Load<Texture2D>("bgStove");
            bgOven = Content.Load<Texture2D>("bgOven");
            emptyBowl = Content.Load<Texture2D>("emptyBowl");
            pot = Content.Load<Texture2D>("pot");
            pan = Content.Load<Texture2D>("pan");
            water = Content.Load<Texture2D>("water");
            sugar = Content.Load<Texture2D>("sugar");
            salt = Content.Load<Texture2D>("salt");
            egg = Content.Load<Texture2D>("egg");
            milk = Content.Load<Texture2D>("milk");
            flour = Content.Load<Texture2D>("flour");
            hintPressE = Content.Load<Texture2D>("hintPressE");
            hintSwipeHoriz = Content.Load<Texture2D>("hintSwipeHoriz");
            hintSwipeVert = Content.Load<Texture2D>("hintSwipeVert");
            hintClick = Content.Load<Texture2D>("hintClick");
            hintSpacebar = Content.Load<Texture2D>("hintSpacebar");
            uiBarBackground = Content.Load<Texture2D>("uiBarBackground");
            uiMeterNeedle = Content.Load<Texture2D>("uiMeterNeedle");
            popupAmazing = Content.Load<Texture2D>("popupAmazing");
            popupGood = Content.Load<Texture2D>("popupGood");
            popupMiss = Content.Load<Texture2D>("popupMiss");
        }

        protected void DrawItem(SpriteBatch sb, Texture2D tex, Vector2 pos, float scale = 0.15f)
        {
            if (tex != null)
            {
                sb.Draw(tex, pos, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        protected void DrawItemPie(SpriteBatch sb, Texture2D tex, Vector2 pos, float scale = 1.2f)
        {
            if (tex != null)
            {
                sb.Draw(tex, pos, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        protected void DrawHint(SpriteBatch sb, Texture2D tex, Vector2 pos, float scale = 0.05f)
        {
            if (tex != null)
            {
                sb.Draw(tex, pos, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        protected void DrawTimerBar(SpriteBatch sb, Vector2 pos)
        {
            if (uiBarBackground != null)
            {
                sb.Draw(uiBarBackground, new Rectangle((int)pos.X, (int)pos.Y, 200, 20), Color.White);
            }
        }

        protected void DrawScaledBackground(SpriteBatch sb, Texture2D tex)
        {
            if (tex != null)
            {
                sb.Draw(tex, new Rectangle(0, 0, 900, 650), Color.White);
            }
        }

        protected bool CheckIfKeyPressed(KeyboardState currentKey, KeyboardState previousKey, Keys requiredKey) 
        { return (currentKey.IsKeyDown(requiredKey) && previousKey.IsKeyUp(requiredKey)); }

        protected bool AddIngredients(KeyboardState currentKey, KeyboardState previousKey, Keys key) 
        { return CheckIfKeyPressed(currentKey, previousKey, key); }

        protected bool Mix(MouseState currentMouse, MouseState previousMouse) 
        { return CheckMouseMovement(currentMouse, previousMouse, false, 1000f); }

        protected bool Wrap(MouseState currentMouse, MouseState previousMouse) 
        { return CheckMouseMovement(currentMouse, previousMouse, false, 1200f); }

        protected bool Cut(MouseState currentMouse, MouseState previousMouse) 
        { return CheckMouseMovement(currentMouse, previousMouse, true, 500f); }

        protected bool Rolling(MouseState currentMouse, MouseState previousMouse) 
        { return CheckMouseMovement(currentMouse, previousMouse, true, 1500f); }

        protected bool Spreading(MouseState currentMouse, MouseState previousMouse) 
        { return CheckMouseMovement(currentMouse, previousMouse, false, 800f); }

        protected bool Boil(KeyboardState currentKey, KeyboardState previousKey, float deltaTime) 
        { return (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space)); }

        protected int Frying(KeyboardState currentKey, KeyboardState previousKey, float deltaTime) 
        { return Bake(currentKey, previousKey, deltaTime); }

        protected int Bake(KeyboardState currentKey, KeyboardState previousKey, float deltaTime) 
        { 
            float speed = 150f;
            if (progressIncreasing) { cookingProgress += speed * deltaTime; if (cookingProgress >= 100f) progressIncreasing = false; }
            else { cookingProgress -= speed * deltaTime; if (cookingProgress <= 0f) progressIncreasing = true; }
            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
            {
                if (cookingProgress >= 40f && cookingProgress <= 60f) return 1; 
                else return 2; 
            }
            return 0;
        }

        protected bool CheckMouseMovement(MouseState currentMouse, MouseState previousMouse, bool isVertical, float requiredDistance)
        {
            if (currentMouse.LeftButton == ButtonState.Pressed)
            {
                float dist = isVertical ? System.Math.Abs(currentMouse.Y - previousMouse.Y) : System.Math.Abs(currentMouse.X - previousMouse.X);
                currentSwipeDistance += dist;
                cookingProgress = (currentSwipeDistance / requiredDistance) * 100f;
                if (currentSwipeDistance >= requiredDistance) { currentSwipeDistance = 0f; return true; }
            }
            return false;
        }

        protected bool CheckMouseClick(MouseState currentMouse, MouseState previousMouse)
        { return (currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released); }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}