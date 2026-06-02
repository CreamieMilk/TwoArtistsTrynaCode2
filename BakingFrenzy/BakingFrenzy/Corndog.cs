using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CookingSimulator
{
    public class Corndog : BakingMethods 
    {
        private Texture2D hotdogRaw, hotdogCut, cheeseBlock, cheeseCut;
        private Texture2D stick, skewerStep1, skewerStep2, skewerFull;
        private Texture2D stick2, skewer2Step1, skewer2Step2, skewer2Full;
        private Texture2D  bowl_Egg,  bowl_EggMilk,  bowl_EggMilkSugar,  bowl_WetUnmixed;
        private Texture2D cornmeal, batter_Cornmeal,  batter_CornmealFlour, bakingPowder, bowl_DoughUnmixed, bowl_BatterReady;
        private Texture2D batteredCorndog;
        private Texture2D  oilBottle, panWithOil, oilBoiling, corndogFrying, corndogCooked;
        private Texture2D ketchup_, corndogCookedKetchup, mustard, corndogFinal;

        private MouseState previousMouse;
        private KeyboardState previousKey;
        
        public void LoadContent(ContentManager Content)
        {
            hotdogRaw = Content.Load<Texture2D>("hotdogRaw");
            hotdogCut = Content.Load<Texture2D>("hotdogCut");
            cheeseBlock = Content.Load<Texture2D>("cheeseBlock");
            cheeseCut = Content.Load<Texture2D>("cheeseCut");
            
            stick = Content.Load<Texture2D>("stick");
            skewerStep1 = Content.Load<Texture2D>("skewerStep1");
            skewerStep2 = Content.Load<Texture2D>("skewerStep2");
            skewerFull = Content.Load<Texture2D>("skewerFull");
            
            stick2 = Content.Load<Texture2D>("stick");
            skewer2Step1 = Content.Load<Texture2D>("skewerStep1");
            skewer2Step2 = Content.Load<Texture2D>("skewerStep2");
            skewer2Full = Content.Load<Texture2D>("skewerFull");
            
            emptyBowl = Content.Load<Texture2D>("emptyBowl");
            egg = Content.Load<Texture2D>("egg");
            bowl_Egg = Content.Load<Texture2D>("bowl_Egg");
            milk = Content.Load<Texture2D>("milk");
            bowl_EggMilk = Content.Load<Texture2D>("bowl_EggMilk");
            sugar = Content.Load<Texture2D>("sugar");
            bowl_EggMilkSugar = Content.Load<Texture2D>("bowl_EggMilkSugar");
            salt = Content.Load<Texture2D>("salt");
            bowl_WetUnmixed = Content.Load<Texture2D>("bowl_WetUnmixed");
            
            cornmeal = Content.Load<Texture2D>("cornmeal");
            batter_Cornmeal = Content.Load<Texture2D>("batter_Cornmeal");
            flour = Content.Load<Texture2D>("flour");
            batter_CornmealFlour = Content.Load<Texture2D>("batter_CornmealFlour");
            bakingPowder = Content.Load<Texture2D>("bakingPowder");
            bowl_DoughUnmixed = Content.Load<Texture2D>("bowl_DoughUnmixed");
            bowl_BatterReady = Content.Load<Texture2D>("bowl_BatterReady");
            
            batteredCorndog = Content.Load<Texture2D>("batteredCorndog");
            
            pan = Content.Load<Texture2D>("pan");
            oilBottle = Content.Load<Texture2D>("oilBottle");
            panWithOil = Content.Load<Texture2D>("panWithOil");
            oilBoiling = Content.Load<Texture2D>("oilBoiling");
            corndogFrying = Content.Load<Texture2D>("corndogFrying");
            corndogCooked = Content.Load<Texture2D>("corndogCooked");
            
            ketchup_ = Content.Load<Texture2D>("ketchup_");
            corndogCookedKetchup = Content.Load<Texture2D>("corndogCookedKetchup");
            mustard = Content.Load<Texture2D>("mustard");
            corndogFinal = Content.Load<Texture2D>("corndogFinal");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKey = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (currentStep)
            {
                case 0: 
                    if (Cut(currentMouse, previousMouse)) currentStep++; 
                    break;
                case 1: 
                    if (Cut(currentMouse, previousMouse)) currentStep++; 
                    break;
                case 2: 
                    if (Cut(currentMouse, previousMouse)) currentStep++; 
                    break;
                case 3: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 4: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
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
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 10: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 11: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 12: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 13: 
                    if (Mix(currentMouse, previousMouse)) currentStep++; 
                    break;
                case 14: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 15: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 16: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 17: 
                    if (Mix(currentMouse, previousMouse)) currentStep++; 
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
                    if (Boil(currentKey, previousKey, deltaTime)) currentStep++; 
                    break;
                case 22: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 23: 
                    int fryResult = Frying(currentKey, previousKey, deltaTime);
                    if (fryResult != 0) 
                    {
                        FinalLevelScore = (fryResult == 1) ? 1 : 2;
                        currentStep++;
                    }
                    break;
                case 24: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 25: 
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++; 
                    break;
                case 26: 
                    if (CheckMouseClick(currentMouse, previousMouse)) 
                    { 
                        IsLevelComplete = true; 
                    } 
                    break;
            }
            previousMouse = currentMouse;
            previousKey = currentKey;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bool isStove = (currentStep >= 20 && currentStep <= 23);
            DrawScaledBackground(spriteBatch, isStove ? bgStove : bgTable);

            switch (currentStep)
            {
                case 0:
                    DrawItem(spriteBatch, hotdogRaw, centerStage);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 1:
                    DrawItem(spriteBatch, hotdogCut, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 2:
                    DrawItem(spriteBatch, cheeseBlock, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawItem(spriteBatch, hotdogCut, corner2);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 3:
                    DrawItem(spriteBatch, stick, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawItem(spriteBatch, cheeseCut, corner2);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 4:
                    DrawItem(spriteBatch, skewerStep1, centerStage);
                    DrawItem(spriteBatch, cheeseCut, corner2);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 5:
                    DrawItem(spriteBatch, skewerStep2, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 6:
                    DrawItem(spriteBatch, stick2, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawItem(spriteBatch, cheeseCut, corner2);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 7:
                    DrawItem(spriteBatch, skewer2Step1, centerStage);
                    DrawItem(spriteBatch, cheeseCut, corner2);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 8:
                    DrawItem(spriteBatch, skewer2Step2, centerStage);
                    DrawItem(spriteBatch, hotdogCut, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 9:
                    DrawItem(spriteBatch, emptyBowl, centerStage);
                    DrawItem(spriteBatch, egg, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 10:
                    DrawItem(spriteBatch, bowl_Egg, centerStage);
                    DrawItem(spriteBatch, milk, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 11:
                    DrawItem(spriteBatch, bowl_EggMilk, centerStage);
                    DrawItem(spriteBatch, sugar, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 12:
                    DrawItem(spriteBatch, bowl_EggMilkSugar, centerStage);
                    DrawItem(spriteBatch, salt, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 13:
                    DrawItem(spriteBatch, bowl_WetUnmixed, centerStage);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 14:
                    DrawItem(spriteBatch, bowl_WetUnmixed, centerStage);
                    DrawItem(spriteBatch, cornmeal, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 15:
                    DrawItem(spriteBatch, batter_Cornmeal, centerStage);
                    DrawItem(spriteBatch, flour, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 16:
                    DrawItem(spriteBatch, batter_CornmealFlour, centerStage);
                    DrawItem(spriteBatch, bakingPowder, corner1);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 17:
                    DrawItem(spriteBatch, bowl_DoughUnmixed, centerStage);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 18:
                    DrawItem(spriteBatch, bowl_BatterReady, centerStage);
                    DrawItem(spriteBatch, skewerFull, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 19:
                    DrawItem(spriteBatch, bowl_BatterReady, centerStage);
                    DrawItem(spriteBatch, batteredCorndog, corner3);
                    DrawItem(spriteBatch, skewer2Full, corner4);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 20:
                    DrawItem(spriteBatch, pan, centerStage);
                    DrawItem(spriteBatch, oilBottle, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 21:
                    DrawItem(spriteBatch, panWithOil, centerStage);
                    DrawTimerBar(spriteBatch, new Vector2(400, 550));
                    DrawHint(spriteBatch, hintSpacebar, hintLocation);
                    break;
                case 22:
                    DrawItem(spriteBatch, oilBoiling, centerStage);
                    DrawItem(spriteBatch, batteredCorndog, corner3);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 23:
                    DrawItem(spriteBatch, corndogFrying, centerStage);
                    DrawTimerBar(spriteBatch, new Vector2(400, 550));
                    DrawHint(spriteBatch, hintSpacebar, hintLocation);
                    break;
                case 24:
                    DrawItem(spriteBatch, corndogCooked, centerStage);
                    DrawItem(spriteBatch, ketchup_, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 25:
                    DrawItem(spriteBatch, corndogCookedKetchup, centerStage);
                    DrawItem(spriteBatch, mustard, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 26:
                    DrawItem(spriteBatch, corndogFinal, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
            }
        }
    }
}