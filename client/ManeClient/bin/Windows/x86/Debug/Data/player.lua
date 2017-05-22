IDLE =            Loader.GetTexture("player/player_idle")

SPACE_DOWN = false;

--moving how many units per second
MOVE_UPS = 3;

--jump height
JUMP = 2;

ManeScript = {

    py = 0,

    Start = function()
        py = gameObject.Position.Y;
    end,

    Update = function()
        if(Input.IsKeyDown('D')) then
            gameObject.Translate(deltaTime * (MOVE_UPS * _UnitSize), 0);
            gameObject.SetToHorizontalVerticalAligned();
        end
        if(Input.IsKeyDown('A')) then
            gameObject.Translate(deltaTime * (MOVE_UPS * -_UnitSize), 0);
            gameObject.SetToHorizontalFlipped();
        end
        if(Input.IsKeyDown(' ') and gameObject.Grounded) then
            if(not SPACE_DOWN) then
                jc_g = -Physics.GravityVal * _UnitSize;
                jc_f = math.sqrt(2 * jc_g * JUMP);
                gameObject.ApplyForce(0, jc_f);
            end
            SPACE_DOWN = true;
        else
            SPACE_DOWN = false;
        end

        grounded = (py != gameObject.Position.Y);
        if(grounded) then
        else
        end
        py = gameObject.Position.Y;

        Rendering.CameraOffset = (Rendering.CameraOffset - gameObject.Position) / 2;
    end,

    Destruct = function()

    end
}