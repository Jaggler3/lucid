IDLE_RIGHT = Loader.GetTexture("player/player_idle_right")
IDLE_FALLING_RIGHT = Loader.GetTexture("player/player_falling_right")

SPACE_DOWN = false;

--moving how many units per second
MOVE_UPS = 3;

ManeScript = {

    py = 0,

    Start = function()
        py = gameObject.Position.Y;
    end,

    Update = function()
        if(Input.IsKeyDown('D')) then
            gameObject.translate(deltaTime * (MOVE_UPS * _UnitSize), 0);
            gameObject.Texture = IDLE_FALLING_RIGHT;
        end
        if(Input.IsKeyDown('A')) then
            gameObject.translate(deltaTime * (MOVE_UPS * -_UnitSize), 0);
        end
        if(Input.IsKeyDown(' ') and gameObject.Grounded) then
            if(not SPACE_DOWN) then
                gameObject.ApplyForce(0, 500);
            end
            SPACE_DOWN = true;
        else
            SPACE_DOWN = false;
        end

        grounded = (py != gameObject.Position.Y);
        if(grounded) then
            gameObject.Texture = IDLE_FALLING_RIGHT
        else
            gameObject.Texture = IDLE_RIGHT;
        end
        py = gameObject.Position.Y;
    end,

    Destruct = function()

    end
}