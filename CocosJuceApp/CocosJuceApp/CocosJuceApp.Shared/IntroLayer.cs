using System;
using System.Collections.Generic;
using System.Diagnostics;
using CocosSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CocosJuceApp.Shared
{
    public class IntroLayer : CCLayerColor
    {
        private CCLabel titleLabel;
        private CCLabel frequencyLabel;
        private CCMenu menu;
        private CCMenuItemToggle onOffSwitch;
        private CCSprite switchOnSprite;
        private CCSprite switchOffSprite;
        private CCSprite frequencyKnob;
        private CCSpriteFrameCache freqKnobSpriteFrameCache;
        private CCSpriteFrameCache onOffSwitchSpriteFrameCache;
        private const int knobPositions = 51;
        private float frequency = 440f;
        private bool isSwitchedOn = false;
        private const float minFrequency = 0f;
        private const float frequencyStep = 40;
        private const float maxFrequency = minFrequency + (frequencyStep * knobPositions);
        private float touchResponsivity = 0.2f;

        public IntroLayer() : base(CCColor4B.Gray)
        {
             titleLabel = new CCLabel("CocosJuce", "fonts/Roboto-Light-72.fnt");
            frequencyLabel = new CCLabel("", "fonts/Roboto-Light-72.fnt");


            onOffSwitchSpriteFrameCache = CCSpriteFrameCache.SharedSpriteFrameCache;
            onOffSwitchSpriteFrameCache.AddSpriteFrames("images/onoffswitch.plist");
            
            switchOnSprite = new CCSprite("switch_on.png");
            switchOffSprite = new CCSprite("switch_off.png");
            onOffSwitch = new CCMenuItemToggle(SwitchToggle, new CCMenuItem[]
                                                         {
                                                             new CCMenuItemImage(switchOffSprite) { }, 
                                                             new CCMenuItemImage(switchOnSprite) { }, 
                                                         });

            menu = new CCMenu(onOffSwitch);

            freqKnobSpriteFrameCache = CCSpriteFrameCache.SharedSpriteFrameCache;
            freqKnobSpriteFrameCache.AddSpriteFrames("images/frequencyknob.plist");


            frequencyKnob = new CCSprite("frequencyknob00.png");
    
            AddChild(titleLabel);
            AddChild(menu);
            AddChild(frequencyLabel);
            AddChild(frequencyKnob);

        }

        private int lastFreqKnobIndex = -1;

        void UpdateFrequency(float f)
        {
            int newFreqKnobIndex = (int) (f/frequencyStep);
            if (newFreqKnobIndex != lastFreqKnobIndex && newFreqKnobIndex >= 0 && newFreqKnobIndex < knobPositions)
            {
                string fileName = String.Format("frequencyknob{0:00}.png", newFreqKnobIndex);
                var spriteFrame = CCSpriteFrameCache.SharedSpriteFrameCache[fileName];
                frequencyKnob.ReplaceTexture(spriteFrame.Texture, spriteFrame.TextureRectInPixels);                
                lastFreqKnobIndex = newFreqKnobIndex;
             
                if (isSwitchedOn)
                {
                    CocosJuce.Api.StartTestTone(f, 0.8f);
                }

                frequencyLabel.Text = minFrequency +  (newFreqKnobIndex * frequencyStep)  + " Hz";
            }
        } 


        void SwitchToggle(object sender)
        {
            if (onOffSwitch.SelectedIndex == 0)
            {
                CocosJuce.Api.StopTestTone();
                isSwitchedOn = false;
            }
            else
            {
                CocosJuce.Api.StartTestTone(frequency, 0.8f);
                isSwitchedOn = true;
            }
            
        }


        protected override void AddedToScene()
        {
            base.AddedToScene();

            var bounds = VisibleBoundsWorldspace;
            var action = new CCScaleTo(1.0f, 1.0f);

            titleLabel.Position = new CCPoint(bounds.Center.X, 50);

            menu.Position = new CCPoint(bounds.Center.X, bounds.MaxY - 100);
            onOffSwitch.Scale = 0.1f;
            onOffSwitch.RunActions(action);

            frequencyLabel.Position = new CCPoint(bounds.Center.X, bounds.Center.Y + 120);
            frequencyKnob.Scale = 0.0f;
            frequencyKnob.Position = bounds.Center;
            frequencyKnob.AnchorPoint = new CCPoint(0.5f, 0.5f);
            frequencyKnob.RunActions(action);

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesMoved = OnTouchesMoved;
            touchListener.OnTouchesEnded = OnTouchesEnded;

            AddEventListener(touchListener, this);

            UpdateFrequency(frequency);

            var appDelegate = Application.ApplicationDelegate as AppDelegate;
            if (appDelegate != null && appDelegate.BackButtonWasPressed != null)
            {
                Schedule((dt) =>
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    {
                        appDelegate.BackButtonWasPressed();
                    }
                });
            }

        }


        private CCTouch lastFrequencyKnobTouch;
        private int lastFreqKnobTouchX;
        private int lastFreqKnobTouchY;

        private void OnTouchesBegan(List<CCTouch> ccTouches, CCEvent ccEvent)
        {
            foreach (CCTouch touch in ccTouches)
            {
                if (touch != null)
                {
                    CCPoint tap = touch.Location;
                    if (frequencyKnob.BoundingBox.ContainsPoint(tap))
                    {
                        lastFrequencyKnobTouch = touch;
                        lastFreqKnobTouchY = (int)lastFrequencyKnobTouch.Location.Y;
                        lastFreqKnobTouchX = (int)lastFrequencyKnobTouch.Location.X;
                        var action = new CCScaleTo(0.1f, 0.9f);
                        frequencyKnob.RunActions(action);
                    }
                }
            }  
        }

        private void OnTouchesMoved(List<CCTouch> ccTouches, CCEvent ccEvent)
        {
            foreach (CCTouch touch in ccTouches)
            {
                if (touch == lastFrequencyKnobTouch)
                {
                    if ((int)touch.Location.Y != lastFreqKnobTouchY || (int)touch.Location.X != lastFreqKnobTouchX)
                    {
                        int deltaY = (int)(touch.Location.Y - lastFreqKnobTouchY);
                        int deltaX = (int)(touch.Location.X - lastFreqKnobTouchX);
                        int delta = Math.Abs(deltaY) >= Math.Abs(deltaX) ? deltaY : deltaX;
                        float newFrequency = frequency += frequencyStep * (int)((float)delta * touchResponsivity);
                        lastFreqKnobTouchY = (int)touch.Location.Y;
                        lastFreqKnobTouchX = (int)touch.Location.X;
                        UpdateFrequency(newFrequency);
                    }
                }
            }
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
            }
            if (lastFrequencyKnobTouch != null)
            {
                lastFrequencyKnobTouch = null;
                lastFreqKnobTouchY = 0;
                lastFreqKnobTouchX = 0;
                var action = new CCScaleTo(0.1f, 1.0f);
                frequencyKnob.RunActions(action);
            }
        }
    }
}

