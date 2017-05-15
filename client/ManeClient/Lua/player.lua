IDLE_RIGHT = Loader.GetTexture("player/player_idle_right")
IDLE_FALLING_RIGHT = Loader.GetTexture("player/player_falling_right")

ManeScript = {
    Start = function()
    end,

    Update = function()
        if(Input.IsKeyDown('D')) then
            gameObject.translate(deltaTime * 100, 0);
            gameObject.Texture = IDLE_FALLING_RIGHT;
        end
        if(Input.IsKeyDown('A')) then
            gameObject.translate(deltaTime * -100, 0);
        end

        py = gameObject.Position.Y;
        gameObject.Position = Physics.Gravity(gameObject.collider, deltaTime * Physics.GravityVal);
        grounded = (py != gameObject.Position.Y);
        if(grounded) then
            gameObject.Texture = IDLE_FALLING_RIGHT
        else
            gameObject.Texture = IDLE_RIGHT;
        end
    end,

    Destruct = function()

    end
}