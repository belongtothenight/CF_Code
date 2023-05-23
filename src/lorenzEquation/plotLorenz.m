% Get 3 components of lorentz system
comparison = 1;
max_t = 1e2;
dt = 1e-2;
x0 = 1;
y0 = 1;
z0 = 1;
sigma = 10;
beta = 8/3;
rho = 28;

[dx, dy, dz, t] = lorenz3components(max_t, dt, x0, y0, z0, sigma, beta, rho);

if comparison == 1
    zdiff = 1e-3;
    z0n = z0 + zdiff;
    [dx1, dy1, dz1, t1] = lorenz3components(max_t, dt, x0, y0, z0n, sigma, beta, rho);
end
% 'z0 = 1 + 1e-3'
% Q1 Plot each components vs. time
figure;
subplot(3,1,1);
plot(t, dx);
if comparison == 1
    hold on;
    plot(t1, dx1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('Time');
ylabel('dx');
title('Q1 dx vs. Time');
subplot(3,1,2);
plot(t, dy);
if comparison == 1
    hold on;
    plot(t1, dy1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('Time');
ylabel('dy');
title('Q1 dy vs. Time');
subplot(3,1,3);
plot(t, dz);
if comparison == 1
    hold on;
    plot(t1, dz1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('Time');
ylabel('dz');
title('Q1 dz vs. Time');

% Q2 Plot each components vs. one another
figure;
plot(dx, dy);
if comparison == 1
    hold on;
    plot(dx1, dy1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('dx');
ylabel('dy');
title('Q2 dy vs. dx');
figure;
plot(dx, dz);
if comparison == 1
    hold on;
    plot(dx1, dz1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('dx');
ylabel('dz');
title('Q2 dz vs. dx');
figure;
plot(dy, dz);
if comparison == 1
    hold on;
    plot(dy1, dz1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)));
end
xlabel('dy');
ylabel('dz');
title('Q2 dz vs. dy');
figure;
plot3(dx, dy, dz);
if comparison == 1
    hold on;
    plot3(dx1, dy1, dz1);
    legend(strcat('z0 = ', num2str(z0)), strcat('z0 = ', num2str(z0), ' + ', num2str(zdiff)), 'Location', 'NorthEast');
end
xlabel('dx');
ylabel('dy');
zlabel('dz');
title('Q2 3D Plot');

