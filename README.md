# Custom D3 Map Visualization in Reveal BI SDK

Welcome to the **Custom D3 Map Visualization** project repository! This repository demonstrates how to create a custom D3-based map visualization with flight path arcs and integrate it seamlessly into a Reveal BI dashboard. This tutorial will guide you through the key steps, concepts, and best practices for building and deploying this custom visualization.


## 🚀 Overview

The Reveal BI SDK empowers developers to create interactive and dynamic dashboards. By leveraging the power of custom visualizations, you can extend Reveal's capabilities to meet specific use cases. In this example, we integrate a D3.js map to visualize flight paths between cities, showcasing features such as:

- **Arcs Representing Flight Paths**: Draw connections between origin and destination locations.
- **Custom Tooltips**: Display detailed data on hover.
- **Dynamic Interactions**: Update the visualization based on user inputs.
- **Performance Optimizations**: Efficiently handle large datasets and minimize browser load.

## 🎯 Features

- **Custom D3 Visualization**: Integrates seamlessly into Reveal BI dashboards.
- **Flight Path Arcs**: Visualize connections with dynamic arcs based on user-selected data.
- **Custom Tooltips and Labels**: Display detailed information on hover with clean, professional styling.
- **Responsive Design**: Adjusts dynamically to screen size and dashboard updates.


## 📽️ Video Walkthrough

Watch the step-by-step guide for this project on YouTube:

```markdown
[![Watch the video](https://img.youtube.com/vi/RPUpJt6POj8/0.jpg)](https://youtu.be/RPUpJt6POj8)
```

## 🛠️ Key Concepts

### 1. Load the Reveal Bridge

Include the `RevealBridge.js` file to connect your visualization to Reveal:

```html
<script src="reveal.bridge.js"></script>
```

### 2. Prepare the Data

Ensure your dataset includes:

- Latitude and longitude for origin and destination.
- Names or IDs for cities and states.
- Any additional data for tooltips or labels.

### 3. Define the D3 Map Layers

Create layers for your visualization:

```javascript
const svg = d3
  .select("#my_dataviz")
  .attr("viewBox", `0 0 ${width} ${height}`)
  .style("width", "100%")
  .style("height", "100%");

const mapLayer = svg.append("g").attr("class", "map-layer");
const arcLayer = svg.append("g").attr("class", "arc-layer");
const cityLayer = svg.append("g").attr("class", "city-layer");
const labelLayer = svg.append("g").attr("class", "label-layer");
```

### 4. Handle Data Updates

Use the `Reveal Bridge` listener to react to changes in the dashboard:

```javascript
window.revealBridgeListener = {
  dataReady: (incomingData) => {
    const processedData = dataToJson(incomingData);
    drawMap(processedData);
  },
};
```

### 5. Draw the Map

Implement the function to render arcs and tooltips:

```javascript
function drawMap(data) {
  arcLayer.selectAll(".flight-path").remove();

  arcLayer
    .selectAll(".flight-path")
    .data(data.links)
    .enter()
    .append("path")
    .attr("class", "flight-path")
    .attr("d", (d) => {
      const start = projection(d.coordinates[0]);
      const end = projection(d.coordinates[1]);
      const dx = end[0] - start[0],
        dy = end[1] - start[1],
        dr = Math.sqrt(dx * dx + dy * dy) * 1.2;
      return `M${start[0]},${start[1]}A${dr},${dr} 0 0,1 ${end[0]},${end[1]}`;
    })
    .style("stroke", "orange")
    .style("fill", "none")
    .on("mouseover", (event, d) => {
      tooltip.style("opacity", 1).html(formatTooltip(d));
    })
    .on("mouseout", () => {
      tooltip.style("opacity", 0);
    });
}
```

### 6. Optimize Performance

- Use filters to reduce dataset size.
- Optimize GeoJSON for faster rendering.
- Minimize the number of arcs and labels.

### 7. Test and Deploy

- Run the .NET Core in the Server folder
- Open Index.html in the Client folder to run the sample


## 📚 Additional Resources

- **Reveal BI Documentation**: [https://www.revealbi.io/](https://www.revealbi.io/)
- **D3 Graph Gallery**: [https://www.d3-graph-gallery.com/](https://www.d3-graph-gallery.com/)
- **Source Code**: [https://github.com/RevealBi-CustomViz/D3FlightMap](https://github.com/RevealBi-CustomViz/D3FlightMap)

---

Bring your data to life with custom visualizations in Reveal BI! If you found this project helpful, please star the repository and share it with your network.

