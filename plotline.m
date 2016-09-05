function plotline(p1, p2, t, k)
%% Plots a line between points p1 and p2 in k segments. 
%% A delay of t seconds is applied beween two line segments
%% 
%% p1, p2: points
%% t: delay applied between drawing two line segments
%% k: number of line segments
%%

    if(nargin < 3)
        t = 0;
    end
    
    if t == 0
        v = [p1; p2];
        plot3(v(:,1), v(:,2), v(:,3), 'LineWidth', 3)
    else
        if(nargin < 4)
            k = 20;
        end
        
        dp = (p2 - p1)/k;
        for r = 1 : k
            v = [p1; p1 + r*dp];
            plot3(v(:,1), v(:,2), v(:,3), 'LineWidth', 3)
            pause(t)
        end
    end
end