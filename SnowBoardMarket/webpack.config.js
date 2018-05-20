const path = require('path');
const webpack = require('webpack');

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    const clientBuldleOutputDir = './wwwroot/dist';
    const serverBuldleOutputDir = './src/dist';

    const clientBundleConfig = {
        resolve: { extensions: ['.js', '.jsx', '.ts', '.tsx'] },
        entry: {
            'main': [
                './src/boot-client.tsx'
            ]
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

    const serverBundleConfig = {
        resolve: { 
            extensions: ['.js', '.jsx', '.ts', '.tsx'],
            mainFields: ['main'] 
        },
        entry: { 'main-server': [
            './src/boot-server.tsx'
        ] },
        plugins: [
        ],
        output: {
            libraryTarget: 'commonjs2',
            path: path.join(__dirname, serverBuldleOutputDir)
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
                }
            ]
        },
        target: 'node',
        devtool: 'inline-source-map',
        mode: isDevBuild ? 'development' : 'production',
    };

    return [clientBundleConfig, serverBundleConfig];
}