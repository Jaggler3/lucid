ManeScript = {
    Start = function()
    end,
    Update = function()
        if(Input.IsKeyDown('D')) then
            gameObject.translate(deltaTime * 100, 0);
        end
    end,
    Destruct = function()

    end
}