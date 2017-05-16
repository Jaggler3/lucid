ManeScript = {
    Start = function()
    end,
    Update = function()
        if(gameObject.MouseClicked) then
            gameObject.Destroy();
        end
    end,
    Destruct = function()
    end
}