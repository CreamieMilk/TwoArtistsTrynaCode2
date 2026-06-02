using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace CookingSimulator
{
    public class Pie : BakingMethods 
    {
        private Texture2D butter, pan_Butter, pan_ButterMelted, pan_ButterMeltedFlour, rouxMix;
        private Texture2D pan_RouxWaterSugar, pieSauce;
        private Texture2D appleRaw, appleSliced, bowl_Apple, cinnamon, bowl_AppleCinnamonSauce, appleCinnamonMix, appleFilling;
        private Texture2D doughBall, pierolledDough, piePan, crustInPan, pieWithFilling;
        private Texture2D doughStrips, pieCrissCross2, eggWashBrush, pieWashed, pieCooked;
        private Texture2D oven_PieRaw;
        
        private MouseState previousMouse;
        private KeyboardState previousKey;

        public void LoadContent(ContentManager Content)
        {
            butter = Content.Load<Texture2D>("butter");
            pan_Butter = Content.Load<Texture2D>("pan_Butter");
            pan_ButterMelted = Content.Load<Texture2D>("pan_ButterMelted");
            pan_ButterMeltedFlour = Content.Load<Texture2D>("pan_ButterMeltedFlour");
            rouxMix = Content.Load<Texture2D>("rouxMix");
            pan_RouxWaterSugar = Content.Load<Texture2D>("pan_RouxWaterSugar");
            pieSauce = Content.Load<Texture2D>("pieSauce");
            
            appleRaw = Content.Load<Texture2D>("appleRaw");
            appleSliced = Content.Load<Texture2D>("appleSliced");
            bowl_Apple = Content.Load<Texture2D>("bowl_Apple");
            cinnamon = Content.Load<Texture2D>("cinnamon");
            bowl_AppleCinnamonSauce = Content.Load<Texture2D>("bowl_AppleCinnamonSauce");
            appleCinnamonMix = Content.Load<Texture2D>("appleCinnamonMix");
            appleFilling = Content.Load<Texture2D>("appleFilling");
            
            doughBall = Content.Load<Texture2D>("doughBall");
            pierolledDough = Content.Load<Texture2D>("rolledDough");
            piePan = Content.Load<Texture2D>("piePan");
            crustInPan = Content.Load<Texture2D>("crustInPan");
            pieWithFilling = Content.Load<Texture2D>("pieWithFilling");
            doughStrips = Content.Load<Texture2D>("doughStrips");
            pieCrissCross2 = Content.Load<Texture2D>("pieCrissCross2");
            eggWashBrush = Content.Load<Texture2D>("eggWashBrush");
            pieWashed = Content.Load<Texture2D>("pieWashed");
            
            oven_PieRaw = Content.Load<Texture2D>("oven_PieRaw");
            pieCooked = Content.Load<Texture2D>("pieCooked");
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
                    if (CheckMouseClick(currentMouse, previousMouse)) currentStep++;
                    break;
                case 2:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 3:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 4:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 5:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 6:
                    if (Cut(currentMouse, previousMouse)) currentStep++;
                    break;
                case 7:
                    if (Cut(currentMouse, previousMouse)) currentStep++;
                    break;
                case 8:
                    if (Cut(currentMouse, previousMouse)) currentStep++;
                    break;
                case 9:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 10:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 11:
                    if (Mix(currentMouse, previousMouse)) currentStep++;
                    break;
                case 12:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 13:
                    if (Rolling(currentMouse, previousMouse)) currentStep++;
                    break;
                case 14:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 15:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 16:
                    if (Rolling(currentMouse, previousMouse)) currentStep++;
                    break;
                case 17:
                    if (Cut(currentMouse, previousMouse)) currentStep++;
                    break;
                case 18:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 19:
                    if (AddIngredients(currentKey, previousKey, Keys.E)) currentStep++;
                    break;
                case 20:
                    if (Spreading(currentMouse, previousMouse)) currentStep++;
                    break;
                case 21:
                    int bakeResult = Bake(currentKey, previousKey, deltaTime);
                    if (bakeResult != 0) 
                    {
                        FinalLevelScore = (bakeResult == 1) ? 1 : 2;
                        currentStep++;
                    }
                    break;
                case 22:
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
            if (currentStep == 21)
            {
                DrawScaledBackground(spriteBatch, oven_PieRaw);
            }
            else if (currentStep == 22)
            {
                DrawScaledBackground(spriteBatch, bgOven);
            }
            else if (currentStep >= 0 && currentStep <= 5)
            {
                DrawScaledBackground(spriteBatch, bgStove);
            }
            else
            {
                DrawScaledBackground(spriteBatch, bgTable);
            }

            switch (currentStep)
            {
                case 0:
                    DrawItem(spriteBatch, pan, centerStage); // Generic
                    DrawItemPie(spriteBatch, butter, corner1); // Pie folder
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 1:
                    DrawItemPie(spriteBatch, pan_Butter, centerStage);
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
                case 2:
                    DrawItemPie(spriteBatch, pan_ButterMelted, centerStage);
                    DrawItem(spriteBatch, flour, corner1); // Generic
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 3:
                    DrawItemPie(spriteBatch, pan_ButterMeltedFlour, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 4:
                    DrawItemPie(spriteBatch, rouxMix, centerStage);
                    DrawItem(spriteBatch, water, corner1); // Generic
                    DrawItem(spriteBatch, sugar, corner2); // Generic
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 5:
                    DrawItemPie(spriteBatch, pan_RouxWaterSugar, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 6:
                    DrawItemPie(spriteBatch, appleRaw, centerStage);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 7:
                    DrawItemPie(spriteBatch, appleRaw, centerStage);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 8:
                    DrawItemPie(spriteBatch, appleRaw, centerStage);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 9:
                    DrawItem(spriteBatch, emptyBowl, centerStage); // Generic
                    DrawItemPie(spriteBatch, appleSliced, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 10:
                    DrawItemPie(spriteBatch, bowl_Apple, centerStage);
                    DrawItemPie(spriteBatch, cinnamon, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 11:
                    DrawItemPie(spriteBatch, bowl_AppleCinnamonSauce, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 12:
                    DrawItemPie(spriteBatch, appleCinnamonMix, centerStage);
                    DrawItemPie(spriteBatch, pieSauce, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 13:
                    DrawItemPie(spriteBatch, doughBall, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 14:
                    DrawItemPie(spriteBatch, piePan, centerStage);
                    DrawItemPie(spriteBatch, pierolledDough, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 15:
                    DrawItemPie(spriteBatch, crustInPan, centerStage);
                    DrawItemPie(spriteBatch, appleFilling, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 16:
                    DrawItemPie(spriteBatch, doughBall, centerStage);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 17:
                    DrawItemPie(spriteBatch, pierolledDough, centerStage);
                    DrawHint(spriteBatch, hintSwipeVert, hintLocation);
                    break;
                case 18:
                    DrawItemPie(spriteBatch, pieWithFilling, centerStage);
                    DrawItemPie(spriteBatch, doughStrips, corner1);
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 19:
                    DrawItemPie(spriteBatch, pieCrissCross2, centerStage);
                    DrawItem(spriteBatch, egg, corner1); // Generic
                    DrawHint(spriteBatch, hintPressE, hintLocation);
                    break;
                case 20:
                    DrawItemPie(spriteBatch, pieCrissCross2, centerStage);
                    DrawItemPie(spriteBatch, eggWashBrush, corner1);
                    DrawHint(spriteBatch, hintSwipeHoriz, hintLocation);
                    break;
                case 21:
                    DrawTimerBar(spriteBatch, new Vector2(400, 550));
                    DrawHint(spriteBatch, hintSpacebar, hintLocation);
                    break;
                case 22:
                    DrawItemPie(spriteBatch, pieCooked, new Vector2(centerStage.X, centerStage.Y - 150));
                    DrawHint(spriteBatch, hintClick, hintLocation);
                    break;
            }
        }
    }
}