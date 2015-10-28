using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;
using System.Drawing;

namespace KBS1.controller
{
    class GameController
    {
        private Form game_Form;
        private GameLoop game_Loop;
        private List<GameObject> game_ObjectList;
        public enum CollisionCalculationMethod
        {
            DIRECTION_RADAR,
            RECTANGLE_CALCULATION,
            OBJECT_PATH
        }
        private CollisionCalculationMethod method = CollisionCalculationMethod.DIRECTION_RADAR;

        public GameController(Form form, GameLoop loop)
        {
            game_Form = form;
            game_Loop = loop;
            game_ObjectList = new List<GameObject>();
        }

        public void Update(List<GameObject> list)
        {
            game_ObjectList = list;

            foreach (GameObject ob in game_ObjectList)
            {
                //Compares the current object against all of the other objects that are in the list
                //2 Ways to do it. Don't know yet which one is better
                bool test = false;
                if (test)
                {
                    var onlyOtherObjects =
                        from value in game_ObjectList
                        where value != ob
                        select value;

                    onlyOtherObjects.ToList().ForEach(ob2 => TestForCollision(ob, ob2));
                }
                else
                {
                    foreach (GameObject ob2 in game_ObjectList)
                    {
                        //Tests if the current object is not the target object (that would cuase problems)
                        if (!ob.Equals(ob2) && ob.isSolidious() && ob2.isSolidious())
                        {
                            //Test for a collision, if there is a collision, call the collide method  
                            TestForCollision(ob, ob2);
                        }
                    }
                }

                //Moves the object one at a time, so that every object has a fair chance to move and collide
                ob.Move();
            }


            //In the end call the repaint method on the form
            game_Form.Invalidate();
            Application.DoEvents();

            //After the update loop, all the AI of every object so that every object can move before taking action on a collision.
            game_ObjectList.ForEach(ob => ob.GiveAllTargetsMeAsTarget());
            game_ObjectList.ForEach(ob => ob.ActivateAI());

            //If the object is dead at the end of the update, remove it from the list
            game_ObjectList.RemoveAll(ob => !ob.isAlive);
        }


        #region CollisionTesting
        //Tests if an object is about to collide with another object and acts on that
        private void TestForCollision(GameObject subject, GameObject target)
        {
            /*

            //If the speed is greater than that the objects size, calculate with the Object Path otherwise, if the object has a low speed, calculate with the Rectangle Calculation
            if (subject.speed_X > subject.width || subject.speed_Y > subject.height)
            {
                method = CollisionCalculationMethod.OBJECT_PATH;
            }
            else
            {
                method = CollisionCalculationMethod.RECTANGLE_CALCULATION;
            }

            */

            


            //Because of the little bug in the Direction Radar, the enemy will continue to use the Object Path method
            switch(subject.Type)
            {
                case GameObject.ObjectType.ENEMY:
                    method = CollisionCalculationMethod.OBJECT_PATH;
                    break;
                default:
                    //Set default method to the Direction Radar. This is the default method for all objects.
                    method = CollisionCalculationMethod.DIRECTION_RADAR;
                    break;
            }



            /*

            
                    NOTICE:
                    Object Path will cause smooth running allong the edges of walls, but you are able to go through them when going diagonal.
                    This will look at the path to the destination and look if there are any objects in the way. (Looks at all the other objects and compares their positions with the subject's speed and direction)

                    Rectangle Calculation will cause no diagonal phasing, but you will get stuck at the edge of a row of walls.       
                    This will look at the destination in stead of the path to it. It can cause problems in jumping/phasing at fast speeds
                    
                    Direction Radar has a little problem with the way that the objects are loaded that causes sticky walls that stop moving objects.
                    This will look in the direction it is headed and checks if there are any objects in the exact path it takes to get to the destination. (The area it checks is as big as the subjects speed)
                    If there is an object in the area, there WILL be a collision.
                    

            */


            //A mix of the Rectangle Calculation and the Object Path Calculation
            //It creates a mix of both positives and ignores the negatives. This should be the main Collision Detection Algorithm
            #region DirectionRadar
            if(method == CollisionCalculationMethod.DIRECTION_RADAR)
            {
                GameObject.Direction horizontalDir = subject.getHorizontalDirection();
                GameObject.Direction verticalDir = subject.getVerticalDirection();

                bool horizontalCollide = false;
                bool verticalCollide = false;
                bool diagonalCollide = false;

                //Check Horizontal Radar
                if (horizontalDir != GameObject.Direction.NONE)
                {
                    switch(horizontalDir)
                    {
                        case GameObject.Direction.EAST:
                            if(subject.Radar_EAST.IntersectsWith(target.ObjectRectangle))
                            {
                                horizontalCollide = true;
                            }
                            break;
                        case GameObject.Direction.WEST:
                            if (subject.Radar_WEST.IntersectsWith(target.ObjectRectangle))
                            {
                                horizontalCollide = true;
                            }
                            break;
                        default:
                            break;
                    }
                }

                //Check Vertical Radar
                if(verticalDir != GameObject.Direction.NONE)
                {
                    switch (verticalDir)
                    {
                        case GameObject.Direction.NORTH:
                            if (subject.Radar_NORTH.IntersectsWith(target.ObjectRectangle))
                            {
                                verticalCollide = true;
                            }
                            break;
                        case GameObject.Direction.SOUTH:
                            if (subject.Radar_SOUTH.IntersectsWith(target.ObjectRectangle))
                            {
                                verticalCollide = true;
                            }
                            break;
                        default:
                            break;
                    }
                }

                //Check Diagonal Radar (only if horizontal and vertical are both not NONE)
                if(horizontalDir != GameObject.Direction.NONE && verticalDir != GameObject.Direction.NONE)
                {
                    //North West
                    if(horizontalDir == GameObject.Direction.WEST && verticalDir == GameObject.Direction.NORTH)
                    {
                        if(subject.Radar_NW.IntersectsWith(target.ObjectRectangle))
                        {
                            diagonalCollide = true;
                        }
                    }
                    //North East
                    if (horizontalDir == GameObject.Direction.EAST && verticalDir == GameObject.Direction.NORTH)
                    {
                        if (subject.Radar_NE.IntersectsWith(target.ObjectRectangle))
                        {
                            diagonalCollide = true;
                        }
                    }

                    //South West
                    if (horizontalDir == GameObject.Direction.WEST && verticalDir == GameObject.Direction.SOUTH)
                    {
                        if (subject.Radar_SW.IntersectsWith(target.ObjectRectangle))
                        {
                            diagonalCollide = true;
                        }
                    }
                    //South East
                    if (horizontalDir == GameObject.Direction.EAST && verticalDir == GameObject.Direction.SOUTH)
                    {
                        if (subject.Radar_SE.IntersectsWith(target.ObjectRectangle))
                        {
                            diagonalCollide = true;
                        }
                    }
                }

                //If there was a horizontal collision, notify the object
                if(horizontalCollide)
                {
                    CollidesWith(subject, target, false);
                }
                //If there was a vertical collision, notify the object
                if (verticalCollide)
                {
                    CollidesWith(subject, target, true);
                }

                //If there was a diagonal collision, check if there was a horizontal collision, is so, notify the object of a horizontal collision
                if(diagonalCollide && subject.hasCollidedHorizontally)
                {
                    CollidesWith(subject, target, false);
                }
                //If there was no horizontal collision but there is a vertical collision, notify the object of a vertical collision
                else if(diagonalCollide && subject.hasCollidedVertically)
                {
                    CollidesWith(subject, target, true);
                }
                //If the object has not had a collision yet, neither horizontal or vertical, noticy the object of a horizontal collision
                else if(diagonalCollide)
                {
                    //This has to do with how the game loads. It loads the items left top to right bottom and it creates a problem, that only going SouthWest creates that specific problem

                    if(verticalDir == GameObject.Direction.SOUTH && horizontalDir == GameObject.Direction.WEST)
                    {
                        CollidesWith(subject, target, true);
                    }
                    else
                    {
                        CollidesWith(subject, target, false);
                    }
                }
            }
            #endregion DirectionRadar

            //Selects the faster method, which can cause warpinig issues, or the slower method, which calculates the collision path even with fast moving objects
            #region RectangleCalculation
            else if (method == CollisionCalculationMethod.RECTANGLE_CALCULATION)
            {
                //Horizontal-Collision-Test
                if (subject.getHorizontalDirection() != GameObject.Direction.NONE && subject.VirtualHorizontalRectangle.IntersectsWith(target.ObjectRectangle))
                {
                    //MessageBox.Show("Test");
                    CollidesWith(subject, target, false);
                }
                //Virtual-Horizontal-Rectangle does Vertical-Collision-Test Test
                else if(subject.getVerticalDirection() != GameObject.Direction.NONE && subject.VirtualRectangle.IntersectsWith(target.ObjectRectangle))
                {
                    CollidesWith(subject, target, true);
                }



                //Vertical-Collision-Test
                if (subject.getVerticalDirection() != GameObject.Direction.NONE && subject.VirtualVerticalRectangle.IntersectsWith(target.ObjectRectangle))
                {
                    CollidesWith(subject, target, true);
                }
                //Virtual-Vertical-Rectangle does Horizontal-Collision-Test Test
                else if(subject.getHorizontalDirection() != GameObject.Direction.NONE && subject.VirtualRectangle.IntersectsWith(target.ObjectRectangle))
                {
                    //MessageBox.Show("Test2");
                    //CollidesWith(subject, target, false);
                }
            }
            #endregion RectangleCalculation

            //For more info, see the comments below near the Object Path Calculation region
            #region ObjectPath
            else if (method == CollisionCalculationMethod.OBJECT_PATH)
            {
                //Tests on horizontaly and verticaly beside the subject
                bool Vertical = TestVerticalCollision(subject, target, false);
                bool Horizontal = TestHorizontalCollision(subject, target, false);

                //Seperate if statements, to test all the possible collisions on the axis
                //And if there was no collision on an axis, make a virtual move and test if the other axis gets a collision
                if (!Vertical)
                {
                    //###MessageBox.Show("Testing virtual collision for the X-axis. (Virtually moved Verticaly)");
                    if (TestHorizontalCollision(subject, target, true) == false)
                    {
                        //###MessageBox.Show("Test completed: No target collision on X-axis");
                        Horizontal = false;
                    }
                    else
                    {
                        //###MessageBox.Show("Collision after test on X-Axis");
                    }
                }
                if (!Horizontal)
                {
                    //###MessageBox.Show("Testing virtual collision for the Y-axis. (Virtually moved Horizontaly)");
                    if (TestVerticalCollision(subject, target, true) == false)
                    {
                        //###MessageBox.Show("Test completed: No target collision on Y-axis");
                        Vertical = false;
                    }
                    else
                    {
                        //###MessageBox.Show("Collision after test on Y-Axis");
                    }
                }

                //After the original collision testing ANd the virtual collision test, look to see if there was a collision on a certain axis
                //Collision on Y
                if (Vertical)
                {
                    //MessageBox.Show("Collision! Vertical");
                    CollidesWith(subject, target, true);
                }
                //Collision on X
                if (Horizontal)
                {
                    //MessageBox.Show("Collision! Horizontal");
                    CollidesWith(subject, target, false);
                }

            }
            #endregion ObjectPath
        }


        //The Object path calculation, it calculates the path towards the target object and calculates if it collides with the target
        //Slower but more accurate
        #region ObjectPathCalculation
        //This has two boolean methods because of the virtual collision tests that accur, 
        //  they need the objects to calculate the collision and a boolean to know if this is a simulated collision test

        private bool TestVerticalCollision(GameObject subject, GameObject target, bool isVirtual)
        {
            //Calculate the distance between the two rectangles

            //If the subject doesn't have a vertical movement, there would be no reason to test vertical collision
            if (subject.getVerticalDirection() == GameObject.Direction.NONE)
            {
                return false;
            }


            //So compare the Y distance            
            bool speedGreaterThanDistance = (/*distance vs speed*/  subject.getVerticalDistanceToObject(target) < subject.speed_Y);


            //if the speed is not greater than the distance, there will be no collision and false can be returned
            //if the speed is greater than the distance, the X sides will be compared to see if they're on the same course and therefore if a collision might occur
            if (speedGreaterThanDistance == false)
            {
                return false;
            }

            //Gets a rectangle from the subject and the target to easily calculate with the virtual data, if needed.
            Rectangle subjectRectangle;
            Rectangle targetRectangle = target.ObjectRectangle;
            if (isVirtual)
            {
                subjectRectangle = subject.VirtualHorizontalRectangle;
            }
            else
            {
                subjectRectangle = subject.ObjectRectangle;
            }

            //compare x sides
            bool outSideComparison = (subjectRectangle.X < targetRectangle.X + targetRectangle.Width);
            bool innerSideComparison = (subjectRectangle.X + subjectRectangle.Width < targetRectangle.X);
            //and if the inner sides are at the same position, no collision will occur, but instead it will graze past it creating non-slowening friction but no collision
            if (subjectRectangle.X + subjectRectangle.Width == targetRectangle.X)
            {
                innerSideComparison = outSideComparison;
            }
            //If the sides are both higher or both lower that the other side, it will not be in the path and there'll be no collision
            if ((outSideComparison == false && innerSideComparison == false) || (outSideComparison == true && innerSideComparison == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool TestHorizontalCollision(GameObject subject, GameObject target, bool isVirtual)
        {
            //If the subject doesn't have a horizontal movement, there would be no reason to test horizontal collision
            if (subject.getHorizontalDirection() == GameObject.Direction.NONE)
            {
                return false;
            }


            //Compare the X distance            
            bool speedGreaterThanDistance = (/*distance vs speed*/  subject.getHorizontalDistanceToObject(target) < subject.speed_X);


            //if the speed is not greater than the distance, there will be no collision and false can be returned
            //if the speed is greater than the distance, the Y sides will be compared to see if they're on the same course and therefore if a collision might occur
            if (speedGreaterThanDistance == false)
            {
                return false;
            }


            Rectangle subjectRectangle;
            Rectangle targetRectangle = target.ObjectRectangle;
            if (isVirtual)
            {
                subjectRectangle = subject.VirtualVerticalRectangle;
            }
            else
            {
                subjectRectangle = subject.ObjectRectangle;
            }

            //compare Y sides
            bool outSideComparison = (subjectRectangle.Y < (targetRectangle.Y + targetRectangle.Height));
            bool innerSideComparison = ((subjectRectangle.Y + subjectRectangle.Height) < targetRectangle.Y);
            //and if the inner sides are at the same position, no collision will occur, but instead it will graze past it creating non-slowening friction but no collision
            if ((subjectRectangle.Y + subjectRectangle.Height) == targetRectangle.Y)
            {
                innerSideComparison = outSideComparison;
            }
            //If the sides are both higher or both lower that the other side, it will not be in the path and there'll be no collision
            if ((outSideComparison == false && innerSideComparison == false) || (outSideComparison == true && innerSideComparison == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion ObjectPathCalculation


        //The Rectangle calculation, it calculates if the endpoint of the move method of an object intersects with the position of another object
        //Faster but more prone to warping issues
        #region RectangleCalculation

        //      This was done in one line at the IF statement above. Inside the second IF statement of the TestForCollision method.

        /*
        EASY MODE Collision detection with rectangles:
        BUT: If the speed is greater than the width or height, the object literly warps over the field and will warp 'through' other objects.
        This can be prevented with a more heavy method to calculate the path towards the target object instead of comparing the end location of an object.
        */
        #endregion RectangleCalculation



        //Method when two objects are going to collide
        private void CollidesWith(GameObject subject, GameObject target, bool isVertical) //isVertical = true --> The Y axis,    isVertical = false --> The X axis
        {
            //Give collision debuff and sets the target to be a collision target in the subject
            if (isVertical)
            {
                subject.verticalCollisionWithObject(target);
            }
            else
            {
                subject.horizontalCollisionWithObject(target);
            }
        }
        #endregion CollisionTesting

    }
}
