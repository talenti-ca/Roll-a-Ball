clear
clc
% p = importdata('output\13_Player.txt');
pts1 = importdata('output/14_East Wall.txt');
pts2 = importdata('output/15_South Wall.txt');
pts3 = importdata('output/16_West Wall.txt');
pts4 = importdata('output/17_North Wall.txt');

disp means
[mean(pts1);mean(pts2);mean(pts3);mean(pts4)]

close all
figure
hold on
grid on

p = [pts1;pts2;pts3;pts4];
axis([min(p(:,1)) max(p(:,1)) min(p(:,2)) max(p(:,2)) min(p(:,3)) max(p(:,3))])
az = -15;
el = -60;
view(az, el);
xlabel('x')
ylabel('y')
zlabel('z')

n = size(p,1);
p0 = [];
p1 = [];
k = 3;
dt = 0;
for t = 1 : k : n
    pts = zeros(k,3);
    for i = 1 : k
        r = t + i - 1;
        pts(i,:) = [p(r,1), p(r,2), p(r,3)];
    end
    
    for i = 1 : k-1
        plotline(pts(i,:), pts(i+1,:), dt);
    end
    plotline(pts(k,:), pts(1,:), dt)
end

