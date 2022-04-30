const path = require("path");
const webpack = require('webpack');

module.exports = {
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            }
        ]
    },
    //experiments: {
    //    outputModule: true
    //},
    //entry: './src/index.js',
    output: {
        path: path.resolve(__dirname, '../wwwroot/js'),
        filename: "crop_core.js",
        library: "CropCore"
    //    library: {
    //        name: "CropCore",
    //        //type: "module"
    //    }
    }
};