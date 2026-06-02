using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CookingSimulator
{
    public class Pizza : BakingMethods 
    {
        private Texture2D yeast, yeastMixture;
        private Texture2D oliveOil, rawDoughBall;
        private Texture2D doughCut, doughInPan;
        private Texture2D tomatoPaste, mint, pizzaSauce;
        private Texture2D rolledDough, sauceSpread, cheese, pepperoni;
        private Texture2D wrap1, wrap2, wrap3;
        private Texture2D oven, pizzaCooked, pizzapot;
        private Texture2D bowl_WaterSugar, bowl_WaterSugarYeast;
        private Texture2D bowl_Flour, bowl_FlourSalt, bowl_FlourSaltOil, bowl_DoughUnmixed;
        private Texture2D pan_Oil, pizzaWithSauce, pizzaWithCheese, pizzaUncooked;
        private Texture2D bowl_Water;
        private Texture2D bowl_TomatoPasteMint, bowl_TomatoPasteMintSalt;
        private MouseState previousMouse;
        private KeyboardState previousKey;
        private int finalScore = 0; 

        public void LoadContent(ContentManager Content)
        {
            yeast = Content.Load<Texture2D>("yeast");
            yeastMixture = Content.Load<Texture2D>("yeastMixture");
            oliveOil = Content.Load<Texture2D>("oliveOil");
            rawDoughBall = Content.Load<Texture2D>("rawDoughBall");
            doughCut = Content.Load<Texture2D>("doughCut");
            doughInPan = Content.Load<Texture2D>("doughInPan");
            tomatoPaste = Content.Load<Texture2D>("tomatoPaste");
            mint = Content.Load<Texture2D>("mint");
            pizzaSauce = Content.Load<Texture2D>("bowl_PizzaSauce");
            rolledDough = Content.Load<Texture2D>("rolledDough");
            sauceSpread = Content.Load<Texture2D>("bowl_PizzaSauce");
            cheese = Content.Load<Texture2D>("cheese");
            pepperoni = Content.Load<Texture2D>("pepperoni");
            wrap1 = Content.Load<Texture2D>("dough_Wrap1 ");
            wrap2 = Content.Load<Texture2D>("dough_Wrap2");
            wrap3 = Content.Load<Texture2D>("dough_WrapFull");
            oven = Content.Load<Texture2D>("oven_PizzaUncooked");
            pizzapot = Content.Load<Texture2D>("pizzaPot");
            pizzaCooked = Content.Load<Texture2D>("pizzaCooked");
            bowl_WaterSugar = Content.Load<Texture2D>("bowl_WaterSugar");
            bowl_WaterSugarYeast = Content.Load<Texture2D>("bowl_WaterSugarYeast");
            bowl_Flour = Content.Load<Texture2D>("bowl_Flour");
            bowl_FlourSalt = Content.Load<Texture2D>("bowl_FlourSalt");
            bowl_FlourSaltOil = Content.Load<Texture2D>("bowl_FlourSaltOil");
            bowl_DoughUnmixed = Content.Load<Texture2D>("bowl_DoughUnmixed");
            bowl_Water = Content.Load<Texture2D>("bowl_Water");
            bowl_TomatoPasteMint = Content.Load<Texture2D>("bowl_TomatoPasteMint");
            bowl_TomatoPasteMintSalt = Content.Load<Texture2D>("bowl_TomatoPasteMintSalt");
            pan_Oil = Content.Load<Texture2D>("pan_Oil");
            pizzaWithSauce = Content.Load<Texture2D>("pizzaWithSauce");
            pizzaWithCheese = Content.Load<Texture2D>("pizzaWithCheese");
            pizzaUncooked = Content.Load<Texture2D>("pizzaUncooked");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKey = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (currentStep)
            {
                case 0:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 1:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 2:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 3:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 4:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 5:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 6:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 7:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 8:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 9:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 10:
                    if (currentKey.IsKeyDown(Keys.E) && previousKey.IsKeyUp(Keys.E)) currentStep++;
                    break;
                case 11:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 12:
                    if (Cut(currentMouse, previousMouse)) currentStep++;
                    break;
                case 13:
                    if (currentKey.IsKeyDown(Keys.E) && previousKey.IsKeyUp(Keys.E)) currentStep++;
                    break;
                case 14:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 15:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 16:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 17:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 18:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 19:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 20:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 21:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 22:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 23:
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 24:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 25:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 26:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 27:
                    if (currentKey.IsKeyDown(Keys.E) && previousKey.IsKeyUp(Keys.E)) currentStep++;
                    break;
                case 28:
                    int bakeResult = Bake(currentKey, previousKey, deltaTime);
                    if (bakeResult != 0)
                    {
                        finalScore = (bakeResult == 1) ? 1 : 2;
                        currentStep++;
                    }
                    break;
                case 29:
                    IsLevelComplete = true;
                    break;
            }

            previousMouse = currentMouse;
            previousKey = currentKey;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawScaledBackground(spriteBatch, (currentStep >= 28) ? bgOven : bgTable);

            switch (currentStep)
            {
                case 0:
                    DrawItem(spriteBatch, emptyBowl, centerStage);
                    DrawItem(spriteBatch, water, corner1);
                    DrawItem(spriteBatch, sugar, corner2);
                    DrawItem(spriteBatch, yeast, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 1:
                    DrawItem(spriteBatch, bowl_Water, centerStage);
                    DrawItem(spriteBatch, sugar, corner2);
                    DrawItem(spriteBatch, yeast, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 2:
                    DrawItem(spriteBatch, bowl_WaterSugar, centerStage);
                    DrawItem(spriteBatch, yeast, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 3:
                    DrawItem(spriteBatch, bowl_WaterSugarYeast, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 4:
                    DrawItem(spriteBatch, yeastMixture, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 5:
                    DrawItem(spriteBatch, emptyBowl, centerStage);
                    DrawItem(spriteBatch, flour, corner1);
                    DrawItem(spriteBatch, salt, corner2);
                    DrawItem(spriteBatch, oliveOil, corner3);
                    DrawItem(spriteBatch, yeastMixture, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 6:
                    DrawItem(spriteBatch, bowl_Flour, centerStage);
                    DrawItem(spriteBatch, salt, corner2);
                    DrawItem(spriteBatch, oliveOil, corner3);
                    DrawItem(spriteBatch, yeastMixture, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 7:
                    DrawItem(spriteBatch, bowl_FlourSalt, centerStage);
                    DrawItem(spriteBatch, oliveOil, corner3);
                    DrawItem(spriteBatch, yeastMixture, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 8:
                    DrawItem(spriteBatch, bowl_FlourSaltOil, centerStage);
                    DrawItem(spriteBatch, yeastMixture, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 9:
                    DrawItem(spriteBatch, bowl_DoughUnmixed, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 10:
                    DrawItem(spriteBatch, rawDoughBall, centerStage);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 11:
                    DrawItem(spriteBatch, wrap3, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 12:
                    DrawItem(spriteBatch, rawDoughBall, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 13:
                    DrawItem(spriteBatch, doughCut, centerStage);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 14:
                    DrawItem(spriteBatch, wrap3, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 15:
                    DrawItem(spriteBatch, pizzapot, centerStage);
                    DrawItem(spriteBatch, oliveOil, corner1);
                    DrawItem(spriteBatch, doughCut, corner2);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 16:
                    DrawItem(spriteBatch, pan_Oil, centerStage);
                    DrawItem(spriteBatch, doughCut, corner2);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 17:
                    DrawItem(spriteBatch, doughInPan, centerStage);
                    break;
                case 18:
                    DrawItem(spriteBatch, emptyBowl, centerStage);
                    DrawItem(spriteBatch, tomatoPaste, corner1);
                    DrawItem(spriteBatch, mint, corner2);
                    DrawItem(spriteBatch, salt, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 19:
                    DrawItem(spriteBatch, tomatoPaste, centerStage);
                    DrawItem(spriteBatch, mint, corner2);
                    DrawItem(spriteBatch, salt, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 20:
                    DrawItem(spriteBatch, bowl_TomatoPasteMint, centerStage);
                    DrawItem(spriteBatch, salt, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 21:
                    DrawItem(spriteBatch, bowl_TomatoPasteMintSalt, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 22:
                    DrawItem(spriteBatch, pizzaSauce, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 23:
                    DrawItem(spriteBatch, rolledDough, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 24:
                    DrawItem(spriteBatch, rolledDough, centerStage);
                    DrawItem(spriteBatch, pizzaSauce, corner1);
                    DrawItem(spriteBatch, cheese, corner2);
                    DrawItem(spriteBatch, pepperoni, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 25:
                    DrawItem(spriteBatch, pizzaWithSauce, centerStage);
                    DrawItem(spriteBatch, cheese, corner2);
                    DrawItem(spriteBatch, pepperoni, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 26:
                    DrawItem(spriteBatch, pizzaWithCheese, centerStage);
                    DrawItem(spriteBatch, pepperoni, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 27:
                    DrawItem(spriteBatch, pizzaUncooked, centerStage);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 28:
                    DrawItem(spriteBatch, oven, new Vector2(centerStage.X, centerStage.Y - 150));
                    DrawTimerBar(spriteBatch, new Vector2(400, 550));
                    DrawHint(spriteBatch, hintSpacebar, hintLocation);
                    break;
                case 29:
                    DrawItem(spriteBatch, pizzaCooked, new Vector2(centerStage.X, centerStage.Y - 150));
                    break;
            }
        }
    }
}