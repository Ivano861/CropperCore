const path = require("path");
const webpack = require('webpack');

module.exports = {
    module: {
        rules: [
            {
                test: /\.(ts)$/,
                exclude: /node_modules/,
                use: {
                    loader: "ts-loader"
                }
            }
        ]
    },
    //experiments: {
    //    outputModule: true
    //},
    resolve: {
        extensions: ['.ts', '.js'],
    },
    optimization: {
        minimize: true
    },
    entry: './src/cropper_wrp.ts',
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