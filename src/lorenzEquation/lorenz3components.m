function [dx, dy, dz, t] = lorenz3components(maxt, dt, x0, y0, z0, sigma, beta, rho)
% LORENZ3COMPONENTS 3 Lorenz system components
%   [dx, dy, dz] = lorenz3components(maxt, dt, x0, y0, z0, sigma, beta, rho)
%   returns the components of the 3D Lorenz system for the given parameters
%   and initial conditions. The components are returned as vectors of
%   length maxt/dt + 1.
%

    lorenzFun = @(t, x) [sigma*(x(2) - x(1)); x(1)*(rho - x(3)) - x(2); x(1)*x(2) - beta*x(3)];

    tspan = 0:dt:maxt;
    init = [x0, y0, z0];
    [t, x] = ode45(lorenzFun, tspan, init);

    dx = x(:, 1)';
    dy = x(:, 2)';
    dz = x(:, 3)';

    % figure;
    % plot3(dx, dy, dz);
end