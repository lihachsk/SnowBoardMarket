const path = require('path');
const webpack = require('webpack');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    const clientBuldleOutputDir = './wwwroot/dist';

    const clientBundleConfig = {
        resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
        entry: {
            'main': './src/boot-client.tsx'
        },
        output: {
            filename: '[name].js',
            path: path.join(__dirname, clientBuldleOutputDir),
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    use: [
                        {
                            loader: 'babel-loader',
                            options: {
                                babelrc: true,
                                plugins: ['react-hot-loader/babel'],
                            },
                        },
                        {
                            loader: 'awesome-typescript-loader?silent=true',
                        }
                    ]
                },
                {
                    test: /\.css$/,
                    use: [
                        {
                            loader: 'style-loader'
                        },
                        {
                            loader: 'css-loader',
                            options: {
                                camelCase: true,
                                modules: true
                            }
                        },
                        {
                            loader: 'typescript-css-modules-loader'
                        }
                    ]
                },
                {
                    test: /\.json$/,
                    use: [
                        {
                            loader: 'json-loader'
                        }
                    ]
                }
            ]
        },
        mode: isDevBuild ? 'development' : 'production',
        plugins: [
        ]
    };

    return [clientBundleConfig];
}