using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trivial_Pursuit.Jeu.Entites;

public class Joueur : Sprite
{
    private string _nom;
    private Case _case;
    private int _score;
    private List <Joker> _jokers;
    public bool Actif {  get; set; } // Permet d'activer ou désactiver les mouvements d'un joueur


    public Joueur(string nom,Texture2D texture, Vector2 position, Case caseD) : base(texture, position,80)
    {
        _nom = nom; 
        _case = caseD; // case de départ
        _score = 0;
        _jokers = new List<Joker>();
        Actif = false; // innactifs à la création
    }

    public void update()
    {
        if (Actif)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up)&& _position.Y>50)
            {
                _position.Y -= 8; 
            }

            if (keyboardState.IsKeyDown(Keys.Down) && _position.Y<850)
            {
                _position.Y += 8;
            }

            if (keyboardState.IsKeyDown(Keys.Right) && _position.X<1550)
            {
                _position.X += 8;
            }

            if (keyboardState.IsKeyDown(Keys.Left) && _position.X>50)
            {
                _position.X -= 8;
            }
        }
    }

    public string GetNom()
    {
        return _nom;
    }
    public int GetScore()
    {
        return _score;
    }
    
    public Case GetCase()
    {
        return _case;
    }
    
    // Modifie la case du joueur et le place à la position de la case
    public void SetCase(Case nouvelleCase)
    {
        _case = nouvelleCase;
        _position = nouvelleCase.GetPosition();
        SetPosition(new Vector2(_position.X+40,_position.Y+40));
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }
    
    public Vector2 GetPosition()
    {
        return _position;
    }


    public new void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}
