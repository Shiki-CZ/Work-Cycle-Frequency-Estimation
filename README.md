# Work Cycle Frequency Estimation Using Voxel Occupancy Analysis

This project focuses on determining the **worker’s operation cycle frequency** based on the number of **occupied voxels** within the robot’s workspace.

## Overview

The main goal was to estimate the worker’s working pace (cycle time) by analyzing spatial occupancy data derived from the environment. The simulation was designed to emulate a human performing repetitive tasks near an industrial robot.

## Methodology

1. **Data Smoothing**  
   Raw voxel occupancy data were smoothed using the **Savitzky–Golay filter** to reduce noise and obtain a more continuous signal.

2. **Frequency Analysis**  
   The smoothed signal was transformed using the **Fast Fourier Transform (FFT)** to identify dominant frequency components.

3. **Cycle Detection**  
   The **fundamental frequency** was extracted from the spectrum and used to calculate the **worker’s operation cycle time**.

## Simulation Environment

Experiments were conducted in **CoppeliaSim**, where a mannequin performed a repetitive motion simulating a typical manual task.  
After each cycle, the mannequin’s movement speed was slightly modified to test the algorithm’s ability to adapt and accurately detect the new working frequency.

The simulation output consisted of the **number of currently occupied voxels** in the workspace at each timestep. To better reflect real-world sensor behavior, **artificial noise** was added to the data to simulate measurement inaccuracies.
